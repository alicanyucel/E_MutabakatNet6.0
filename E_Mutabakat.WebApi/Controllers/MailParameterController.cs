using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Mutabakat.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailParameterController : ControllerBase
    {
        private readonly IMailParameterService _mailParameterService;

        public MailParameterController(IMailParameterService mailParameterService)
        {
            _mailParameterService = mailParameterService;
        }


        [HttpPost("update")]
        public IActionResult MailParameter(MailParameter mailParameter)
        {
           var result = _mailParameterService.Update(mailParameter);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
