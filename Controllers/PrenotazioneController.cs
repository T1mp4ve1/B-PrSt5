using Hotel.Models;
using Hotel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class PrenotazioneController : Controller
    {
        private readonly IPrenotazioneService _services;
        private readonly ICamereService _camereService;
        private readonly UserManager<ClienteModel> _userManager;

        public PrenotazioneController(
            IPrenotazioneService services,
            ICamereService camere,
            UserManager<ClienteModel> userManager)
        {
            _services = services;
            _camereService = camere;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var camere = await _camereService.GetAllAsync();
            ViewBag.Camere = camere;

            var prenotazioni = await _services.GetAllAsync();
            ViewBag.Prenotazioni = prenotazioni;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(PrenotazioneModel model)
        {

            var user = await _userManager.GetUserAsync(User);
            model.ClienteId = user.Id;
            model.Stato = true;
            await _services.CreateAsync(model);
            return RedirectToAction("Index");
        }

        //
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var prenotazione = await _services.GetByIdAsync(id);
            if (prenotazione == null) return NotFound();

            ViewBag.Camere = await _camereService.GetAllAsync();
            return View(prenotazione);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(PrenotazioneModel model)
        {
            ViewBag.Camere = await _camereService.GetAllAsync();
            await _services.UpdateAsync(model);
            return RedirectToAction("Index");

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _services.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}