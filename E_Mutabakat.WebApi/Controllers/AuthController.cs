using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Entities.Concrete;
using E_Mutabakat.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Mutabakat.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register(UserCompanyRegisterDto userCompanyRegisterDto)
        {

            var registerResult = _authService.Register(userCompanyRegisterDto.UserForRegister, userCompanyRegisterDto.UserForRegister.Password, userCompanyRegisterDto.company);

           
            return BadRequest(registerResult.Message);
        }


    
    [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLogin)
        {
            var userToLogin = _authService.Login(userForLogin);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            return Ok(userToLogin);
        }
        [HttpGet("confirmuser")]
        public IActionResult ConfirmUser(string value)
        {

            return Ok();
        }
    }
}