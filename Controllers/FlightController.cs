using Microsoft.AspNetCore.Mvc;
using myFlightapp.IServices;
using myFlightapp.Models;
using System.Threading.Tasks;

namespace myFlightapp.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService flightService;
        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }
        public async Task<IActionResult> Index(long id, FlightModel model)
        {
            var flights = await this.flightService.DeleteFlight(id);

            return View(flights);
        }
        public async Task<IActionResult> CreateFlight(FlightModel model)
        {
            var flights = await this.flightService.CreateFlight(model);

            return View(flights);
        }
        public IActionResult ViewDetails(int Id)
        { 
            return View();
        }
    }
}
