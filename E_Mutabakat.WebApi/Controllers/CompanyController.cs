using E_Mutabakat.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Mutabakat.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyServices _companyServices;
        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }
        [HttpGet("GetCompanyList")]
        public IActionResult GetCompanyList()
        {
            var result=_companyServices.GetList();
            if(result.Success)
            {
                return Ok(result);
            }
            // veriler basarılı bir sekilde çekildi.
            return BadRequest(result.Message);
        }
    }
}
