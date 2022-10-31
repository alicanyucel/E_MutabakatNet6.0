using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Constans;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.Entities.Concrete;
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
        private readonly ICurrencyAccountService _currencyAccountService;
        public AccountReconcilitionManager(IAccountReconciliationDal accountReconciliationDal, ICurrencyAccountService currencyAccountService)
        {
            _accountReconciliationDal = accountReconciliationDal;
            _currencyAccountService = currencyAccountService;
        }

        public IResult Add(AccountReconclition accountReconciliation)
        {
            _accountReconciliationDal.Add(accountReconciliation);
            return new SuccessResult(Messages.AddAccountReconciliatian);
        }

        public IResult Delete(AccountReconclition accountReconclition)
        {
            _accountReconciliationDal.Delete(accountReconclition);
            return new SuccessResult(Messages.DeleteAccountReconciliation);
        }

        public IDataResult<AccountReconclition> GetById(int id)
        {
            return new SuccesDataResult<AccountReconclition>(_accountReconciliationDal.Get(p => p.Id == id));

        }

        public IDataResult<List<AccountReconclition>> GetList(int companyid)
        {
            return new SuccesDataResult<List<AccountReconclition>>(_accountReconciliationDal.GetList(p => p.CompanyId == companyid));
                
           
        }

        public IResult Update(AccountReconclition accountReconclition)
        {
            _accountReconciliationDal.Update(accountReconclition);
            return new SuccessResult(Messages.UpdateAccountReconciliation);
        }
    }
}
