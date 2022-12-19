using É_Mutabakat.Core.Ultilities.Result.Abstract;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Abstract
{
   public interface IBabsReconciliationService
    {
        IResult Add(BaBsReconcilition baBsReconcilition);
        IResult AddExcel(string filepath, int companyId);
        IResult Update(BaBsReconcilition baBsReconcilition);
        IResult Delete(BaBsReconcilition baBsReconcilition);
        IDataResult<BaBsReconcilition> GetById(int id);
        IDataResult<List<BaBsReconcilition>> GetList(int companyid);

    }
}
