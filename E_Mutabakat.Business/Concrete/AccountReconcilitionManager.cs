using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.BusinessAspect;
using E_Mutabakat.Business.Constans;
using E_Mutabakat.Core.Aspect.Autofac.Transaction;
using E_Mutabakat.Core.Aspect.Caching;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.DataAccess.Concrete.EntityFrameWork;
using E_Mutabakat.Entities.Concrete;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
    public class AccountReconcilitionManager : IAccountReconcliationService
    {
        private readonly IAccountReconciliationDal _accountReconciliationDal;
        private readonly ICurrencyAccountService _currencyAccountService;
        public AccountReconcilitionManager(IAccountReconciliationDal accountReconciliationDal, ICurrencyAccountService currencyAccountService)
        {
            _accountReconciliationDal = accountReconciliationDal;
            _currencyAccountService = currencyAccountService;
        }
        // securedde aşağıdaki seyden alınır
        [SecurityOperation("AccountReconclition.Add")]
        // cacheaspcetde ise servisten get ile alınır.
        [CacheRemoveAspect("IAccountReconcliationService.Get")]
        public IResult Add(AccountReconclition accountReconciliation)
        {
            _accountReconciliationDal.Add(accountReconciliation);
            return new SuccessResult(Messages.AddAccountReconciliatian);
        }


        [CacheRemoveAspect("IAccountReconcliationService.Get")]
        [TransactionScopeAspect]
        public IResult AddExcel(string filePath, int companyId)

        {

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))

            {

                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {





                    while (reader.Read())

                    {

                        string code = reader.GetString(0);





                        if (code != "Cari Kodu")

                        {

                            if (code != null)

                            {

                                string startingDate = Convert.ToDateTime(reader.GetValue(1)).ToString("dd/MM/yyyy");

                                string endingDate = Convert.ToDateTime(reader.GetValue(1)).ToString("dd/MM/yyyy");

                                string currencyId = reader.GetValue(3).ToString();

                                string debit = reader.GetValue(4).ToString();

                                string credit = reader.GetValue(5).ToString();



                                //int CurrencyAccountId = _currencyAccountService.GetByCode(code, companyId).Data.Id;

                                AccountReconclition accountReconciliation = new AccountReconclition()

                                {

                                    CompanyId = companyId,

                                    //CurrencyAccountId = CurrencyAccountId,

                                    CurrenyCredit = Convert.ToDecimal(credit),

                                    CurrencyDebit = Convert.ToDecimal(debit),

                                    CurrencyId = Convert.ToInt16(currencyId),

                                    StartingDate = Convert.ToDateTime(startingDate),

                                    EndingDate = Convert.ToDateTime(endingDate),

                                };

                                _accountReconciliationDal.Add(accountReconciliation);

                            }



                        }

                    }





                }

            }

            return new SuccessResult(Messages.AddAccountReconciliatian);

        }
        [CacheRemoveAspect("IAccountReconcliationService.Get")]
        public IResult Delete(AccountReconclition accountReconclition)
        {
            _accountReconciliationDal.Delete(accountReconclition);
            return new SuccessResult(Messages.DeleteAccountReconciliation);
        }

        public IDataResult<AccountReconclition> GetById(int id)
        {
            return new SuccesDataResult<AccountReconclition>(_accountReconciliationDal.Get(p => p.Id == id));

        }
        [CacheRemoveAspect("IAccountReconcliationService.Get")]
        [CacheAspect(60)]
        public IDataResult<List<AccountReconclition>> GetList(int companyid)
        {
            return new SuccesDataResult<List<AccountReconclition>>(_accountReconciliationDal.GetList(p => p.CompanyId == companyid));


        }
        [CacheRemoveAspect("IAccountReconcliationService.Get")]
        public IResult Update(AccountReconclition accountReconclition)
        {
            _accountReconciliationDal.Update(accountReconclition);
            return new SuccessResult(Messages.UpdateAccountReconciliation);
        }
    }
}
