using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrojaRestaurant.DataAccess;
using TrojaRestaurant.DataAccess.Repository.IRepository;
using TrojaRestaurant.Models;

namespace TrojaRestaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> OrderData = _unitOfWork.Order.GetAll();
            return View(OrderData);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Order.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Order created succesfully";
                return RedirectToAction("Index");
                
            }
            return View(obj);
        }

        //EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var orderFromDbFirst = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);

            if(orderFromDbFirst == null)
            {
                return NotFound();
            }
            return View(orderFromDbFirst);
        }


        //UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Order.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var orderFromDbFirst = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);

            if(orderFromDbFirst == null)
            {
                return NotFound();
            }
            return View(orderFromDbFirst);
        }

        //UPDATE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Order.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Order deleted  succesfully";
            return RedirectToAction("Index");
        }
    }
}
