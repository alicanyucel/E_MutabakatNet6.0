using E_Mutabakat.Business.Abstract;
using E_Mutabakat.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
   public class AccountReconcilitionManager:IAccountReconcliationService
    {
        private readonly IAccountReconciliationDal _accountReconciliationDal;

        public AccountReconcilitionManager(IAccountReconciliationDal accountReconciliationDal)
        {
            _accountReconciliationDal = accountReconciliationDal;
        }
    }
}
