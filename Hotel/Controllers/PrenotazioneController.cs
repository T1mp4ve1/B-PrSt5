using Hotel.Models;
using Hotel.Services;
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
    }
}