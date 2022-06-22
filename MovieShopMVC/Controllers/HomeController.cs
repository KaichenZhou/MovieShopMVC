using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;
using Infrastructure.Services;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMovieService _movieService;
        //depend on higher level abstraction

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
            // you want to have control over which implentation that you want to use 
            //var homeController = new HomeController();
        }

        public IActionResult Index()
        {
            //var homeController = new HomeController(new Logger(),);
            //home page;
            //top 30 movies -> movie service
            //instance of MovieService class
            //newing up
            //refactor this code
            //var movieService = new MovieService();
            var movies = _movieService.GetTopGrossingMovies();
            //method(int x, IMovieService service);
            //var movieService = new MovieService();
            //var movieService3 = new MovieTestService();

            //method(3,movieService3);
            //passing the data from Controller/Action method  to the view
            return View(movies);
        }
        [HttpGet]
        public IActionResult TopRatedMovies()
        {
            //call the movie service
            //movie service will call movie repository
            //move repository will call the database to get the data
            return View();
        }

        public IActionResult Privacy()
         {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}