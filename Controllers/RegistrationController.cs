using Hotel.Models;
using Hotel.Services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        public async Task<IActionResult> AddUser(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var res = await _registrationService.CreateUserAsync(model);

                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> List()
        {
            var users = await _registrationService.GetAllAsync();
            var userRoles = new Dictionary<string, IList<string>>();

            foreach (var u in users)
            {
                var roles = await _registrationService.GetRolesAsync(u);
                userRoles[u.Id] = roles;
            }
            var vm = new RegistrationViewModel
            {
                Utenti = users,
                Ruoli = userRoles,
                NuovoDipendente = new RegistrationModel()
            };
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddStaff(RegistrationViewModel model)
        {
            var res = await _registrationService.CreateAdminAsync(model.NuovoDipendente);

            if (res.Succeeded)
            {
                return RedirectToAction("List");
            }
            else
            {
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            model.Utenti = await _registrationService.GetAllAsync();
            model.Ruoli = new Dictionary<string, IList<string>>();
            foreach (var u in model.Utenti)
            {
                model.Ruoli[u.Id] = await _registrationService.GetRolesAsync(u);
            }

            return View("List", model);
        }

        ///

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var res = await _registrationService.DeleteUserAsync(id);
            if (res.Succeeded)
                return RedirectToAction("List");

            foreach (var error in res.Errors)
                ModelState.AddModelError("", error.Description);

            return RedirectToAction("List");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = (await _registrationService.GetAllAsync()).FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            var model = new RegistrationModel
            {
                Email = user.Email,
                Nome = user.Nome,
                Cognome = user.Cognome,
                Telefono = user.PhoneNumber
            };
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, RegistrationModel model)
        {
            var updatedUser = new ClienteModel
            {
                Id = id,
                Email = model.Email,
                UserName = model.Email,
                Nome = model.Nome,
                Cognome = model.Cognome,
                PhoneNumber = model.Telefono
            };

            var res = await _registrationService.UpdateUserAsync(updatedUser);
            if (res.Succeeded)
                return RedirectToAction("List");

            foreach (var error in res.Errors)
                ModelState.AddModelError("", error.Description);
            return View(model);
        }
    }
}