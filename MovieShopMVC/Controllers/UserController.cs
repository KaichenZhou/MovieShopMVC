using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;

namespace MovieShopMVC.Controllers
{
    [Authorize]

    public class UserController : Controller
    {
        //all these action methods should only be execute when user is loged in
        private readonly ICurrentLogedInUser _currentLogedInUser;

        public UserController(ICurrentLogedInUser currentLogedInUser)
        {
            _currentLogedInUser = currentLogedInUser;
        }

        [HttpGet]
        //write a code that will check if user is authenification
        //Filters
        public async Task<IActionResult> Purchases()
        {
            //go to database and get all the movies purchased by user, user id
            //var cookie = this.HttpContext.Request.Cookies["MovieShopAuthCookie"];
            //can create a class the exposes HttpContext cookie decrypted indo and claims
            var userId = _currentLogedInUser.UserId;
            //use the UserID and send to user service to get info for the User
            return View();

        }

        [HttpGet]

        public async Task<IActionResult> Favorites()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReview()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite()
        {
            return View();
        }
        [HttpPost]         
        
        public async Task<IActionResult> BuyMovie()
            {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View();
        }

    }
}
