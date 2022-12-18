using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Constans;
using E_Mutabakat.Core.Aspect.Autofac.Transaction;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.DataAccess.Concrete.EntityFrameWork;
using E_Mutabakat.Entities.Concrete;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        [TransactionScopeAspect]
        public IResult AddToExcel(string Filepath, int companyId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(Filepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);
                        string startingDate =reader.GetString(1);
                        string endingDate =reader.GetString(2);
                        string currencyId =reader.GetString(3);
                        string debit =reader.GetString(4);
                        string credit =reader.GetString(5);
                       

                        if (code != "Cari Kodu")
                        {
                           int currencyAcountId = _currencyAccountService.GetByCode(code, companyId).Data.Id;
                            AccountReconclition accountReconclition = new AccountReconclition()
                            {

                                CompanyId = companyId,
                                CurrencyAccountId =currencyAcountId,
                                CurrencyId = Convert.ToInt32(currencyId),
                                CurrenyCredit = Convert.ToDecimal(credit),
                                CurrencyDebit = Convert.ToDecimal(debit),
                                StartingDate = Convert.ToDateTime(startingDate),
                                EndingDate = Convert.ToDateTime(endingDate)
                            };
                            _accountReconciliationDal.Add(accountReconclition);
                        }
                    }
                }
            }
            return new SuccessResult(Messages.AddedCurrencyAccount);
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
