using É_Mutabakat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Entities.Concrete
{
   public class AccountReconclition:IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int CurrencyAccountId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int CurrencyId { get; set; }
        public decimal CurrencyDebit { get; set; }
        public decimal CurrenyCredit { get; set; }
        public bool IsSendEmail { get; set; }
        public DateTime? SendEmailDate { get; set; }
        public bool? IsEmailRead { get; set; }
        public DateTime? EmailReadDate { get; set; }
        public bool? JsResultSucceed { get; set; }
        public DateTime? ResultDate { get; set; }
        public string? ResultNote { get; set; }

    }
}
