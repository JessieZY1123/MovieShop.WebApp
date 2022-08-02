using Microsoft.AspNetCore.Mvc;

namespace MovieShop.WebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
