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
        [HttpPost("registersecondaccount")]

        public IActionResult RegistersSecondAccount(UserforRegistertoSecondAccountDto userforRegister)
        {

            var userExists = _authService.UserExists(userforRegister.Email);
                if(!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerresult = _authService.RegisterSecondAccount(userforRegister,userforRegister.Password, userforRegister.companyid);
            var result = _authService.CreateAccessToken(registerresult.Data,userforRegister.companyid);
            if(result.Success)
            {

                return Ok(result.Data);
            }

            return BadRequest(registerresult.Message);
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
            var user = _authService.GetByMailConfirmValue(value).Data;
            user.MailConfirm = true;
            user.MailConfirmDate = DateTime.Now;
           var result= _authService.Update(user);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("sendConfirmEmail")]
        public IActionResult sendConfirmEmail(int id)
        {
            var user = _authService.GetById(id).Data;

           
            var result = _authService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}