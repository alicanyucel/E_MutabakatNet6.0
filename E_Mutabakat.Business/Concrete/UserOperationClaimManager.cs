using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.BusinessAspect;
using E_Mutabakat.Business.Constans;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.Entities.Concrete;
using E_Mutabakat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }
        
        

        [SecurityOperation("Admin,UserOperationClaim.Add")]
  
        
        public IResult Add(UserOperationClaim userOperationClaim)
    {
        _userOperationClaimDal.Add(userOperationClaim);
        return new SuccessResult(Messages.AddedUserOperationClaim);
    }

    [SecurityOperation("Admin,UserOperationClaim.Delete")]
    public IResult Delete(UserOperationClaim userOperationClaim)
    {
        _userOperationClaimDal.Delete(userOperationClaim);
        return new SuccessResult(Messages.DeletedUserOperationClaim);
    }

    [SecurityOperation("Admin,UserOperationClaim.Get")]
    public IDataResult<UserOperationClaim> GetById(int id)
    {
        return new SuccesDataResult<UserOperationClaim>(_userOperationClaimDal.Get(i => i.Id == id));
    }

    [SecurityOperation("Admin,UserOperationClaim.GetList")]
    public IDataResult<List<UserOperationClaim>> GetList(int userId, int companyId)
    {
        return new SuccesDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetList(p => p.UserId == userId && p.CompanyId == companyId));
    }

    public IDataResult<List<UserOperationClaimDto>> GetListDto(int userId, int companyId)
    {
        return new SuccesDataResult<List<UserOperationClaimDto>>(_userOperationClaimDal.GetListDto(userId, companyId));
    }

    [SecurityOperation("Admin,UserOperationClaim.Update")]
    public IResult Update(UserOperationClaim userOperationClaim)
    {
        _userOperationClaimDal.Update(userOperationClaim);
        return new SuccessResult(Messages.UpdatedUserOperationClaim);
    }

        IDataResult<List<UserOperationClaimDto>> IUserOperationClaimService.GetListDto(int userId, int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
