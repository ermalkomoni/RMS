using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrojaRestaurant.DataAccess.Repository.IRepository;
using TrojaRestaurant.Models.ViewModels;

namespace TrojaRestaurant.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartViewModel ShoppingCartViewModel { get; set; }
        public int OrderTotal { get; set; }

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCartViewModel = new ShoppingCartViewModel()
            {
                ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value,
                includeProperties: "Product")
            };

            //Calculating price
            foreach(var cart in ShoppingCartViewModel.ListCart)
            {
                cart.Price = GetPrice(cart.Count, cart.Product.Price);
                ShoppingCartViewModel.CartTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartViewModel);
        }

        public IActionResult Summary()
        {
/*            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCartViewModel = new ShoppingCartViewModel()
            {
                ListCart = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value,
                includeProperties: "Product")
            };

            //Calculating price
            foreach (var cart in ShoppingCartViewModel.ListCart)
            {
                cart.Price = GetPrice(cart.Count, cart.Product.Price);
                ShoppingCartViewModel.CartTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartViewModel);*/
            return View();  
        }

        //Adding Items in cart
        public IActionResult Plus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
            _unitOfWork.ShoppingCart.IncrementCount(cart, 1);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //Decrementing Items in cart
        public IActionResult Minus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
            if(cart.Count <= 1)
            {
                _unitOfWork.ShoppingCart.Remove(cart);
            }
            else 
            {
            _unitOfWork.ShoppingCart.DecrementCount(cart, 1);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //Removing Items in cart
        public IActionResult Remove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == cartId);
            _unitOfWork.ShoppingCart.Remove(cart);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }


        private double GetPrice(double quantity, double price)
        {
            return price;
        }
    }
}
