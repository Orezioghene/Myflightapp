using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myFlightapp.IServices;
using System.Threading.Tasks;

namespace myFlightapp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IFlightService flightService;
        public AdminController(IFlightService flightService)
        {
            this.flightService = flightService;
        }
        // GET: AdminController
        public async Task<IActionResult> Index()
        {
            var getFlights = await this.flightService.GetAllFlight();
            return View(getFlights);
        }


        // GET: AdminController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var getFlight =await this.flightService.GetFlight(id);
            return View(getFlight);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var getFlight = await this.flightService.GetFlight(id);
            return View(getFlight);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteFlight = await this.flightService.DeleteFlight(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: AdminController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
