using Microsoft.AspNetCore.Mvc;
using TrojaRestaurant.Data;

namespace TrojaRestaurant.Controllers
{
    public class MenuController : Controller
    {
        private readonly DataContext _context;

        public MenuController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Menus.ToList();
            return View();
        }
    }
}
