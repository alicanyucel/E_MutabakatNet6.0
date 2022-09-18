using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Ultilities.Security.Jwt
{
   public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get;set ; }
        public int CompanyId { get; set; }

    }
}
