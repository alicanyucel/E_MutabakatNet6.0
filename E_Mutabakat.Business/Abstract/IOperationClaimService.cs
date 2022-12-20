using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using E_Mutabakat.Entities;
using System.Threading.Tasks;
using E_Mutabakat.Entities.Concrete;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using IResult = É_Mutabakat.Core.Ultilities.Result.Abstract.IResult;

namespace E_Mutabakat.Business.Abstract
{
  public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);
        IDataResult<List<OperationClaim>> GetList();
        IDataResult<OperationClaim> GetById(int id);


    }
}
