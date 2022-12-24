using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrojaRestaurant.Data;

namespace TrojaRestaurant.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allOrders = await _context.Orders.ToListAsync();
            return View();
        }
    }
}
