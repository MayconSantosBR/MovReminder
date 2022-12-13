using Microsoft.AspNetCore.Mvc;
using MovReminder.Data.Entities;
using MovReminder.Services.Interfaces;
using System.Data;

namespace MovReminder.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IGeneralService service;
        public RegisterController(IGeneralService service)
        {
            this.service = service;
        }
        public IActionResult RegisterUser()
        {
            return View("RegisterUser");
        }

        public async Task<IActionResult> RegisterNewMovie()
        {
            ViewBag.Genders = await service.GetGendersAsync();

            return View("RegisterMovie");
        }

        public async Task<IActionResult> RegisterMovie()
        {
            ViewBag.Movies = await service.GetMoviesAsync();
            ViewBag.Directors = await service.GetDirectorsAsync();

            return View("RegisterMovieWatched");
        }

        public async Task<IActionResult> CreateMovie(string movieName, string directorId, int genderId, DateTime data, int duration)
        {
            var response = HttpContext.Session.Get("Logado");

            if (response.FirstOrDefault().Equals(1))
            {
                if (await service)
                    return RedirectToAction("Index", "Home");
                else
                    return RedirectToAction("RegisterMovie");
            }
            else
                return RedirectToAction("Login", "Login");
        }

        public async Task<IActionResult> CreateUser(string email, string password, string username)
        {
            try
            {
                if (await service.CreateUserAsync(username, password, email))
                    return RedirectToAction("Login", "Login");
                else
                    return RedirectToAction("RegisterUser");
            }
            catch
            {
                return RedirectToAction("RegisterUser");
            }
        }
        public async Task<IActionResult> CreateWatchedMovie(int movie, DateTime dataView, string feedback)
        {
            try
            {
                var response = HttpContext.Session.Get("Logado");

                if (response.FirstOrDefault().Equals(1))
                {
                    if (await service.CreateWatchedMovieAsync(Convert.ToInt32(HttpContext.Session.Get("User").FirstOrDefault()), movie, dataView, feedback))
                        return RedirectToAction("Index", "Home");
                    else
                        return RedirectToAction("RegisterMovieWatched");
                }
                else
                    return RedirectToAction("Login", "Login");
            }
            catch
            {
                return RedirectToAction("RegisterMovieWatched");
            }
        }
    }
}
