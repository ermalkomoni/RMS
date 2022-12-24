using Microsoft.AspNetCore.Mvc;
using TrojaRestaurant.Data;

namespace TrojaRestaurant.Controllers
{
    public class ReservationController : Controller
    {
        private readonly DataContext _context;

        public ReservationController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ReservationData = _context.Reservations.ToList();
            return View();
        }
    }
}
