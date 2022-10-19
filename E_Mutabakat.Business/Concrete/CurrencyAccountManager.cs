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
    public class CurrencyAccountManager:ICurrencyAccountService
    {
        private readonly ICurrencyAccountDal _currencyAccountDal;
        public CurrencyAccountManager(ICurrencyAccountDal currencyAccountDal)
        {
            _currencyAccountDal = currencyAccountDal;
        }

        public IResult Add(CurrencyAccount currenycAccount)
        {
            _currencyAccountDal.Add(currenycAccount);
            return new SuccessResult(Messages.AddedCurrencyAccount);
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

        public IResult Update(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Update(currencyAccount);
            return new SuccessResult(Messages.UpdateCurrencyAccount);
        }
    }
}
