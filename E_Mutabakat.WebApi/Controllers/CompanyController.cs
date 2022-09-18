using E_Mutabakat.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Mutabakat.WebApi.Controllers
{
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
            return BadRequest(result.Message);
        }
    }
}
