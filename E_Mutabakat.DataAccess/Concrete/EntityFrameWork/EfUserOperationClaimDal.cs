using É_Mutabakat.Core.DataAccess.EntityFramework;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.DataAccess.Concrete.EntityFrameWork.Context;
using E_Mutabakat.Entities.Concrete;
using E_Mutabakat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.DataAccess.Concrete.EntityFrameWork
{
    public class EfUserOperationClaimDal : EfEntityFrameworkBase<UserOperationClaim, ContextDb>, IUserOperationClaimDal
    {
        public List<UserOperationClaimDto> GetListDto(int userId, int companyId)
        {
            using (var context = new ContextDb())
            {
                var result = from userOperationClam in context.UserOperationClaims.Where(x => x.UserId == userId && x.CompanyId == companyId)
                             join operationClaim in context.OperationClaims on userOperationClam.OperationClaimId equals operationClaim.Id
                             select new UserOperationClaimDto
                             {
                                 UserId = userId,
                                 Id = operationClaim.Id,
                                 CompanyId = companyId,
                                 OperationClaimId = operationClaim.Id,
                                 OperationClaimName = operationClaim.Name
                             };
                return result.ToList();



            }
        }
    }
}
