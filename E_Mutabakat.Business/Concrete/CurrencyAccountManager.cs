using E_Mutabakat.Business.Abstract;
using E_Mutabakat.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
    public class CurrencyAccountManager:ICurrencyAccountService
    {
        private readonly ICurrencyAccountDal _currencyAccountDal;
        public CurrencyAccountManager(ICurrencyAccountDal currencyAccountDal)
        {
            _currencyAccountDal = currencyAccountDal;
        }
    }
}
