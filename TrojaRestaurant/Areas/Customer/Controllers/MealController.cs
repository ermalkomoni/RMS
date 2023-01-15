using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrojaRestaurant.DataAccess;

namespace TrojaRestaurant.Areas.Customer.Controllers
{
    public class MealController : Controller
    {
        private readonly DataContext _context;

        public MealController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allMeals = await _context.Meals.ToListAsync();
            return View();
        }
    }
}
