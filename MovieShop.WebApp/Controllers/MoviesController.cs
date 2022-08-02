using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.WebApp.Controllers
{

    public class MoviesController : Controller
    {
        IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await movieService.GetMovieDetailsAsync(id);
            return View(movieDetails);
        }
    }
}
