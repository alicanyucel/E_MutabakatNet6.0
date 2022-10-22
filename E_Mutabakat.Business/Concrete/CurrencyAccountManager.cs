using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Constans;
using E_Mutabakat.Business.ValidationRules.FluentValidation;
using E_Mutabakat.Core.Aspect.Autofac.Transaction;
using E_Mutabakat.Core.Aspect.Autofac.Validation;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.Entities.Concrete;
using ExcelDataReader;
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
        [ValidationAspect(typeof(CurrencyAccountValidator))]

        public IResult Add(CurrencyAccount currenycAccount)
        {
            _currencyAccountDal.Add(currenycAccount);
            return new SuccessResult(Messages.AddedCurrencyAccount);
        }
        [ValidationAspect(typeof(CurrencyAccountValidator))]
        [TransactionScopeAspect]

        public IResult AddToExcel(string filepath)
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
                                IdentityNumber=identityNumber,
                                Email = email,
                                Authrorized = authorized,
                                AddedAt = DateTime.Now,
                                Code = code,
                             
                            };
                        }
                    }
                }
            }
            return new SuccessResult("ok"); 
        }
        public IResult Delete(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Delete(currencyAccount);
            return new SuccessResult(Messages.DeleteCurrencyAccount);
        }

        public IDataResult<CurrencyAccount> Get(int id)
        {
            return new SuccesDataResult<CurrencyAccount>(_currencyAccountDal.Get(p => p.Id == id));

        }

        public IDataResult<List<CurrencyAccount>> GetList(int companyId)
        {
            return new SuccesDataResult<List<CurrencyAccount>>(_currencyAccountDal.GetList(p=>p.CompanyId==companyId));
        }
        [ValidationAspect(typeof(CurrencyAccountValidator))]
        public IResult Update(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Update(currencyAccount);
            return new SuccessResult(Messages.UpdateCurrencyAccount);
        }
    }
}
