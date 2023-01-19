using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrojaRestaurant.DataAccess;
using TrojaRestaurant.DataAccess.Repository.IRepository;
using TrojaRestaurant.Models;
using TrojaRestaurant.Models.ViewModels;

namespace TrojaRestaurant.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork; //in the course it's used "_db"
        private readonly IWebHostEnvironment _hostEnvironment;

        public MenuController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        //GET
        public IActionResult Upsert(int? id)
        {
            MenuViewModel menuViewModel = new()
            {
                Menu = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                })
            };
            
            
            if (id == null || id == 0)
            {
                //create menu
                /*ViewBag.CategoryList = CategoryList;*/
                return View(menuViewModel);
            }
            else
            {
                //update menu
                menuViewModel.Menu = _unitOfWork.Menu.GetFirstOrDefault(u=>u.Id == id);
                return View(menuViewModel);
            } 
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MenuViewModel obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //uploading image to folder
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\menus");
                    var extension = Path.GetExtension(file.FileName);

                    //when we are updating an image we first delete the existing image
                    //removing old image
                    if(obj.Menu.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Menu.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    //coping files
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    //saving to database, updating url
                    obj.Menu.ImageUrl = @"\images\menus\" + fileName + extension;
                }
                if(obj.Menu.Id == 0) 
                { 
                    _unitOfWork.Menu.Add(obj.Menu);
                }
                else
                {
                    _unitOfWork.Menu.Update(obj.Menu);
                }
                _unitOfWork.Save();
                TempData["success"] = "Menu created succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //adding WEB API
        #region API CALLS
        [HttpGet]

        public IActionResult GetAll()
        {
            var menuList = _unitOfWork.Menu.GetAll(includeProperties:"Category");
            return Json(new { data = menuList });
        }

        //Delete

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Menu.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Menu.Remove(obj); 
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
