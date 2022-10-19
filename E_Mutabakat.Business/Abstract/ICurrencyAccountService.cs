using É_Mutabakat.Core.Ultilities.Result.Abstract;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Abstract
{
    public interface ICurrencyAccountService
    {
        IDataResult<List<CurrencyAccount>> GetList(int companyId);
        IDataResult<CurrencyAccount> Get(int id);
        IResult Delete(CurrencyAccount currencyAccount);
        IResult Update(CurrencyAccount currencyAccount);
        IResult Add(CurrencyAccount currenycAccount);
    }
}
