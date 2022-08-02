using Microsoft.AspNetCore.Mvc;

namespace MovieShop.WebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
