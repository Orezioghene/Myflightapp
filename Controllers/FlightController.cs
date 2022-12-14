using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> FlightList()
        {
            var getFlights = await this.flightService.GetAllFlight();
            return View(getFlights);
        }

        public async Task<IActionResult> BookFLight(int id)
        {
            var getFlight = await this.flightService.GetFlight(id);
            FlightBookingModel flightBook = new FlightBookingModel
            {
                Id = getFlight.Id,
                Flight_name = getFlight.FlightName,
                Destination = getFlight.destination,
                Amount = getFlight.TripAmount,
                Location=getFlight.departure
            };
            return View(flightBook);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookFLight(FlightBookingModel flighbookingmodel)
        {
            try
            {
                var getFlight = await this.flightService.GetFlight(flighbookingmodel.Id);
                flighbookingmodel.Destination = getFlight.destination;
                flighbookingmodel.Amount= getFlight.TripAmount;
                flighbookingmodel.Flight_name = getFlight.FlightName;
                var bookFlight = await this.flightService.BookFlight(flighbookingmodel);

                var responselink = bookFlight.data;

                return Redirect(responselink);
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> VerifyPayment(string transactionId)
        {
            try
            { return RedirectToAction(nameof(FlightList));
            }
            catch
            {
                return View();
            }
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
