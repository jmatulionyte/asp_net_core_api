using System.Net;
using asp_net_core_rest_api.Models;
using asp_net_core_rest_api.Models.Dto;
using asp_net_core_rest_api.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp_net_core_rest_api.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]

    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        protected APIResponse _response;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
            this._response = new();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _userRepo.Login(model);
            //no user with name and password
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token)) {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password incorrect");
                return BadRequest(_response);
            }
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            return View();
        }
    }
}

