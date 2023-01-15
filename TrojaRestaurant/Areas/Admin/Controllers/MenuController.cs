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

        public MenuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Menu> MenuData = _unitOfWork.Menu.GetAll();
            return View(MenuData);
        }
        //Edit
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
                //create product
                /*ViewBag.CategoryList = CategoryList;*/
                return View(menuViewModel);
            }
            else
            {
                //update product
            }
            return View(menuViewModel);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MenuViewModel obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //_unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        //Update

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
