using Microsoft.AspNetCore.Mvc;
using MovReminder.Models;
using MovReminder.Services.Interfaces;
using System.Diagnostics;

namespace MovReminder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGeneralService service;

        public HomeController(ILogger<HomeController> logger, IGeneralService service)
        {
            _logger = logger;
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var response = HttpContext.Session.Get("Logado");

            if (response.FirstOrDefault().Equals(1))
            {
                ViewBag.Watcheds = await service.GetWatchedMoviesAsyncById(Convert.ToInt32(HttpContext.Session.Get("User").FirstOrDefault()));
                return View();
            }
            else
                return RedirectToAction("Login", "Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}