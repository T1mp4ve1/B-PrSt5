using Hotel.Models;
using Hotel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _loginService.LoginAsync(model.Email, model.Password, model.RememberMe);

                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("", "Login non valido");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _loginService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
