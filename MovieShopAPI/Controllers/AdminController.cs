using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public AdminController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [Route("movie")]

        public async Task<IActionResult> Index()
        {

            return Ok();
        }

        [HttpPut]
        [Route("movie")]

        public async Task<IActionResult> Index2()
        {

            return Ok();
        }

        [HttpGet]
        [Route("top-purchased-movies")]
        public async Task<IActionResult> Index3()
        {
            
            return Ok();
        }
    }
}
