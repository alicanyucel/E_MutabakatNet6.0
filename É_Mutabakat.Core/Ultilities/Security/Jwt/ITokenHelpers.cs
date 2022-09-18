using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Ultilities.Security.Jwt
{
   public interface ITokenHelpers
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims, int companyid);

    }
}
