using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public UserController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpPut]
        [Route("details")]

        public async Task<IActionResult> Index1()
        {

            return Ok();
        }

        [HttpPost]
        [Route("purchase-movie")]
        public async Task<IActionResult> Index2()
        {

            return Ok();
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> Index3()
        {
            return Ok();
        }

        [HttpPost]
        [Route("un-favorite")]
        public async Task<IActionResult> Index4()
        {
            return Ok();
        }

        [HttpGet]
        [Route("check-movie-favorite/{movieId}")]
        public async Task<IActionResult> Index5()
        {
            return Ok();
        }

        [HttpPost]
        [Route("add-review")]
        public async Task<IActionResult> Index6()
        {
            return Ok();
        }

        [HttpPut]
        [Route("edit-review")]
        public async Task<IActionResult> Index7()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("delete-review/{movieId}")]
        public async Task<IActionResult> Index8()
        {
            return Ok();
        }

        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> Index9()
        {
            return Ok();
        }

        [HttpGet]
        [Route("purchases-details/{movieId}")]
        public async Task<IActionResult> Index10()
        {
            return Ok();
        }

        [HttpGet]
        [Route("check-movie-purchased/{movieId}")]
        public async Task<IActionResult> Index11()
        {
            return Ok();
        }

        [HttpGet]
        [Route("favorites")]
        public async Task<IActionResult> Index12()
        {
            return Ok();
        }

        [HttpGet]
        [Route("movie-reviews")]
        public async Task<IActionResult> Index13()
        {
            return Ok();
        }
    }
}
