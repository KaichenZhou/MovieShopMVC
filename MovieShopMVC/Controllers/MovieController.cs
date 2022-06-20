using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
       //showing the detail of the movie
       public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieDetails(id);
            return View(movie);
        }
    }
}
