using Hotel.Models;
using Hotel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var users = await _registrationService.GetAllAsync();
            var userRoles = new Dictionary<string, IList<string>>();

            foreach (var u in users)
            {
                var roles = await _registrationService.GetRolesAsync(u);
                userRoles[u.Id] = roles;
            }
            ViewBag.Role = userRoles;
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _registrationService.CreateUserAsync(model);

                if (res.Succeeded)
                    return RedirectToAction("Index", "Home");

                foreach (var error in res.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
    }
}