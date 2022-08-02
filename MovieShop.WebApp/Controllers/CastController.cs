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

        public async Task<ActionResult> Detail(int id)
        {

            var cast = await this.castService.GetCastDetail(id)
;
            return View(cast);
        }
    }
}
