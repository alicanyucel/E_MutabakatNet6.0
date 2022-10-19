using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Entities.Dtos
{
    public class CurrencyAccountExcelDto
    {
        public IFormFile File { get; set; }
        public int CompanyId { get; set; }
    }
}
