using É_Mutabakat.Core.Ultilities.Result.Abstract;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Abstract
{
    public interface IAccountReconciliationDetailService
    {
        IResult Add(AccountReconcilitionDetail accountReconciliationDetail);
        IResult AddExcel(string filepath, int accountReconciliationId);
        IResult Update(AccountReconcilitionDetail accountReconclitionDetail);
        IResult Delete(AccountReconcilitionDetail accountReconclitionDetail);
        IDataResult<AccountReconcilitionDetail> GetById(int id);
        IDataResult<List<AccountReconcilitionDetail>> GetList(int arId);

    }
}
