using Microsoft.AspNetCore.Mvc;
using MovReminder.Services.Interfaces;

namespace MovReminder.Controllers
{
    public class LoginController : Controller
    {
        private readonly IGeneralService service;
        private readonly byte[] isLogin = { 1 };
        private readonly byte[] notLogin = { 0 };
        public LoginController(IGeneralService service)
        {
            this.service = service;
        }
        public IActionResult Login()
        {
            HttpContext.Session.Set("Logado", notLogin);

            return View();
        }

        public async Task<IActionResult> ValidateLogin(string email, string password) 
        {
            try
            {
                var id = await service.ValidateUserExistsAsync(email);
                var valid = await service.ValidateCredentialsAsync(email, password);

                if (id != 0 && valid == true)
                {
                    byte[] user = { Convert.ToByte(id) };
                    HttpContext.Session.Set("User", user);
                    HttpContext.Session.Set("Logado", isLogin);
                    return RedirectToAction("Index", "Home");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
