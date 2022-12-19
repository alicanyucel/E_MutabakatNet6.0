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
        IResult Add(AccountReconclition accountReconciliation);
        IResult AddExcel(string filepath,int companyId);
        IResult Update(AccountReconclition accountReconclition);
        IResult Delete(AccountReconclition accountReconclition);
        IDataResult<AccountReconclition> GetById(int id);
        IDataResult<List<AccountReconclition>> GetList(int companyid);
       
    }
}
