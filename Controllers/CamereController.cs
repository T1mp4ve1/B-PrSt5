using Hotel.Models;
using Hotel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class CamereController : Controller
    {
        private readonly ICamereService _camServices;

        public CamereController(ICamereService camServices) { _camServices = camServices; }

        public async Task<IActionResult> Index()
        {
            var tipi = await _camServices.TypeGetAllAsync();
            ViewBag.Tipi = tipi;

            var camere = await _camServices.GetAllAsync();
            ViewBag.Camere = camere;

            return View();
        }

        //tipi
        [HttpPost]
        public async Task<IActionResult> AddTypeRoom(TipoCamera type)
        {
            await _camServices.TypeCreateAsync(type);
            return RedirectToAction("Index");
        }

        //camere
        [HttpPost]
        public async Task<IActionResult> AddRoom(CameraModel camera)
        {
            if (await _camServices.GetAllAsync().ContinueWith(t => t.Result.Any(c => c.Numero == camera.Numero)))
            {
                ModelState.AddModelError("Numero", "Camera con questo numero esiste gia");
                //ViewBag.Tipi = await _camServices.TypeGetAllAsync();
                //ViewBag.Camere = await _camServices.GetAllAsync();
                return RedirectToAction("Index");
            }
            await _camServices.CreateAsync(camera);
            return RedirectToAction("Index");
        }
    }
}
