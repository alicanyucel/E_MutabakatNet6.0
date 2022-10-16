using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Mutabakat.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailTemplateController : ControllerBase
    {
        private readonly IMailTemplateService _mailTemplateservice;
        public MailTemplateController(IMailTemplateService mailTemplateservice)
        {
            _mailTemplateservice = mailTemplateservice; 
        }
        [HttpPost("add")]
        public IActionResult Add(MailTemplate  mailTemplate )
        {
            var result = _mailTemplateservice.Add(mailTemplate);
            if(!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
    }
}
