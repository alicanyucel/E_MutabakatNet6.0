using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Entities.Concrete;
using E_Mutabakat.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Mutabakat.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyAccountController : ControllerBase
    {
        private readonly ICurrencyAccountService _currencyAccountService;
        public CurrencyAccountController(ICurrencyAccountService currencyAccountService)
        {
            _currencyAccountService = currencyAccountService;
        }
        [HttpPost("addFromExcel")]
        public IActionResult AddfromExcel(CurrencyAccountExcelDto currencyAccount)
        {
            if (currencyAccount.File.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + ".xlsx";
                var filePath = $"({Directory.GetCurrentDirectory()}/Content/{fileName})";
                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    currencyAccount.File.CopyTo(stream);
                    stream.Flush();
                }
                var result = _currencyAccountService.AddToExcel(filePath);
                if (result.Success)
                {
                    return Ok(result);
                }
                
                return BadRequest(result.Message);
            }
            return BadRequest("Dosya secimi yapmadiniz");
        }
        [HttpPost("add")]
        public IActionResult Add(CurrencyAccount currencyAccount)
        {
            var result = _currencyAccountService.Add(currencyAccount);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("getbyId")]
        public IActionResult GetById(int id)
        {
            var result = _currencyAccountService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getlist")]
        public IActionResult GetList(int companyid)
        {
            var result = _currencyAccountService.GetList(companyid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CurrencyAccount currencyAccount)
        {
            var result = _currencyAccountService.Delete(currencyAccount);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Update")]
        public IActionResult Update(CurrencyAccount currencyAccount)
        {
            var result = _currencyAccountService.Update(currencyAccount);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
