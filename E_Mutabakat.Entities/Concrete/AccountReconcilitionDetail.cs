using É_Mutabakat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Entities.Concrete
{
    //best practise tablolarda cogul classlarda tekil isimlendişrme yap.
 public class AccountReconcilitionDetail:IEntity
    {
        // boş clas kalmasın diye yukarıda core katmanında entities klasoru acıp içine Ientity ekledik
        // sonrasında referasn verdik
        public int Id { get; set; }
        public int AccountReconciliationsId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CurrencyId { get; set; }
        public decimal CurrencyDebit { get; set; }
        public decimal CurrencyCredit { get; set; }

    }
}
