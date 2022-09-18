using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddNameIdentitfier(this ICollection<Claim>  claims ,string nameIdentitfier )
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentitfier));
        }
        public static void AddEmail(this ICollection<Claim> claims,string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }
        public static void AddName(this ICollection<Claim> claims,string Name)

        {
            claims.Add(new Claim(ClaimTypes.Name, Name));
        }
         public static void AddRoles(this ICollection<Claim> claims,string[] rolls)
        {
            rolls.ToList().ForEach(roll => claims.Add(new Claim(ClaimTypes.Role,roll)));
        }

        public static void AddCompany(this ICollection<Claim> claims,string company)
        {
            claims.Add(new Claim(ClaimTypes.Anonymous, company));
        }
    }
}
