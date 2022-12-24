using Microsoft.AspNetCore.Mvc;
using TrojaRestaurant.Data;

namespace TrojaRestaurant.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var CategoryData = _context.Categories.ToList();
            return View();
        }
    }
}
