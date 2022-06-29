using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public AccountController(IAccountService accountService,
                                IConfiguration configuration,
                                IUserRepository userRespository)
        {
            _accountService = accountService;
            _configuration = configuration;
            _userRepository = userRespository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            var user = await _accountService.RegisterUser(model);
            return Ok(user);
        }

        [HttpGet]
        [Route("check-email")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound(new { errorMessage = "The email not found in DB" });
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            var user = await _accountService.ValidateUser(model.Email, model.Password);
            // return a token...
            // JWT Json Web Token
            // iOS, Android app oe Web APP (Angular or React)
            //
            //
            if (user == null)
            {
                return NotFound(new { errorMessage = "The user has not registered" });
            }

            return Ok(user);
        }

    }
}
