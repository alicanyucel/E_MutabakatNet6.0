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
        public IResult AddToExcel(string filepath, int companyId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(filepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);
                        string name = reader.GetString(1);
                        string address = reader.GetString(2);
                        string taxDepartment = reader.GetString(3);
                        string taxIdNumber = reader.GetString(4);
                        string identityNumber = reader.GetString(5);
                        string email = reader.GetString(6);
                        string authorized = reader.GetString(7);

                        if (code != "Cari Kodu")
                        {
                            CurrencyAccount currencyAccount = new CurrencyAccount()
                            {
                                Name = name,
                                Address = address,
                                TaxDepartment = taxDepartment,
                                TaxIdentityNumber = taxIdNumber,
                                IdentityNumber = identityNumber,
                                Email = email,
                                Authrorized = authorized,
                                AddedAt = DateTime.Now,
                                Code = code,
                                CompanyId = companyId,
                                IsActive = true
                            };
                            _currencyAccountDal.Add(currencyAccount);
                        }

                    }
                }
            }
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
