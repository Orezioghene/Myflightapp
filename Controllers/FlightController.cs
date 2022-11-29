using Microsoft.AspNetCore.Mvc;

namespace myFlightapp.Controllers
{
    public class FlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Booking()
        {
            return View();
        }
    }
}
