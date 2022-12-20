using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.BusinessAspect;
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
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOpetationClaimDal _opetationClaimDal;
        public OperationClaimManager(IOpetationClaimDal opetationClaimDal)
        {
            _opetationClaimDal = opetationClaimDal;

        }

        [SecurityOperation("Admin")]
        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccesDataResult<OperationClaim>(_opetationClaimDal.Get(i => i.Id == id));
        }

        [SecurityOperation("Admin")]
        public IResult Add(OperationClaim operationClaim)
        {
            _opetationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.AddedOperationClaim);
        }
        [SecurityOperation("Admin")]
        public IResult Delete(OperationClaim operationClaim)
        {
            _opetationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.DeletedOperationClaim);
        }
        [SecurityOperation("Admin")]
        public IDataResult<List<OperationClaim>> GetList()
        {
           return new SuccesDataResult<List<OperationClaim>>(_opetationClaimDal.GetList());
        }
        [SecurityOperation("Admin")]
        public IResult Update(OperationClaim operationClaim)
        {
            _opetationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.UpdatedOperationClaim);
        }
    }
}
