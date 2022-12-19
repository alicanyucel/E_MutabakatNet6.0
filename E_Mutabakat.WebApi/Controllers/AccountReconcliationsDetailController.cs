using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Mutabakat.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountReconcliationsDetailController : ControllerBase
    {
        private readonly IAccountReconciliationDetailService _service;
        public AccountReconcliationsDetailController(IAccountReconciliationDetailService service)
        {
            _service = service;
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(AccountReconcilitionDetail accountReconclition)
        {
            var result = _service.Delete(accountReconclition);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetList")]
        public IActionResult GetList(int companyid)
        {
            var result = _service.GetList(companyid);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result.Message);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("Update")]
        public IActionResult Update(AccountReconcilitionDetail accountReconclition)
        {

            var result = _service.Update(accountReconclition);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("addFromExcels")]
        public IActionResult AddFromExcels(IFormFile file, int accountreconclitionİd)
        {
            if (file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + ".xlsx";
                var filePath = $"{Directory.GetCurrentDirectory()}/Content/{fileName}";
                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
                var result =_service.AddExcel(filePath,accountreconclitionİd);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result.Message);
            }
            return BadRequest("Dosya secimi yapmadiniz");
        }
        [HttpPost("add")]
        public IActionResult Add(AccountReconcilitionDetail accountReconclition)
        {
            var result = _service.Add(accountReconclition);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
