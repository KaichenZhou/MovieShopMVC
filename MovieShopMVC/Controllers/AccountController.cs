using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(UserLoginModel model)
        {
            var user =await  _accountService.ValidateUser(model.Email, model.Password);
            if (user != null)
            {
                //redirect to home page
                //create a cookie, cookies are always sent from browser automatically to server
                //Inside the cookie we store encrypted info that server can recognize and tell 
                //whether user is loded in or not
                //Cookie should have an expration time such as 2 hours
                var claims = new List<Claim>
                {
                   new Claim (ClaimTypes.Email, model.Email),
                   new Claim (ClaimTypes.Surname, user.LastName),
                   new Claim (ClaimTypes.GivenName, user.FirstName),
                   new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                   new Claim (ClaimTypes.DateOfBirth, user.DateOfBirth.ToShortDateString()),
                   new Claim (ClaimTypes.Country, "USA"),
                   new Claim ("Language", "English"),
                };

                //create the cookie and it will have the above info along with the expiration time
                //do not share above indo in the cookie as plain text, instead encrypt the above info.
                //we need to tell ASP.Net, we are using cookie based authentication so that asp.net can 
                //generate cookie based on the setting we provided.
                //Identity object that will indentity that user with claims
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //principle object with is used by asp.net to recoginzie the user
                //create the cookie with above info
                //httpContext => Encapsualtes your http request info
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal
                    (identity)); 
                return LocalRedirect("~/");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            //show the empty register page when we make a GET Request
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            var user = await _accountService.RegisterUser(model);
            //redirect to login page
            return RedirectToAction("Login");
        }
        
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
 