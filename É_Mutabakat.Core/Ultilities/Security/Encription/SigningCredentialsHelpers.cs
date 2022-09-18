using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Ultilities.Security.Encription
{
   public class SigningCredentialsHelpers
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {

            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
                
        }
    }
}
