using É_Mutabakat.Core.Ultilities.Result.Abstract;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Abstract
{
   public interface IAccountReconcliationService
    {
        IResult Add(AccountReconclitionDetail accountReconciliation);
        IResult AddExcel(string filepath,int companyId);
        IResult Update(AccountReconclitionDetail accountReconclition);
        IResult Delete(AccountReconclitionDetail accountReconclition);
        IDataResult<AccountReconclitionDetail> GetById(int id);
        IDataResult<List<AccountReconclitionDetail>> GetList(int companyid);
       
    }
}
