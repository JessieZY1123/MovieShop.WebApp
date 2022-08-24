using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.WebApp.Controllers
{
    public class CastController : Controller
    {
        ICastService castService;
        public CastController(ICastService _Service)
        {
            castService = _Service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> CastDetails(int id)
        {

            var cast = await castService.GetCastDetail(id)
;
            return View(cast);
        }
    }
}
