using É_Mutabakat.Core.DataAccess.EntityFramework;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.DataAccess.Concrete.EntityFrameWork.Context;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.DataAccess.Concrete.EntityFrameWork
{
    public class EfUserDal : EfEntityFrameworkBase<User, ContextDb>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user, int companyid)
        {
            using (var context= new ContextDb())
            {
                var result = from OperationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                             on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.Id == companyid && UserOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id=OperationClaim.Id,
                                 Name=OperationClaim.Name,
                             };
                return result.ToList();

            }
        }
    }
}
