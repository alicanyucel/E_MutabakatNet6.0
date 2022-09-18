using E_Mutabakat.Core.Extensions;
using E_Mutabakat.Core.Ultilities.Security.Encription;
using E_Mutabakat.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Ultilities.Security.Jwt
{
    public class JwtHelpers : ITokenHelpers
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        DateTime _accesstokenExpiration;
        private readonly object SecuritykeyHelpers;

        public JwtHelpers(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims, int companyid)
        {
            _accesstokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securitkey = SecurityKeyHelpers.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signipCreditionals = SigningCredentialsHelpers.CreateSigningCredentials(securitkey);
            var Jwt = CreateJwtSecurityToken(_tokenOptions, user, signipCreditionals, operationClaims, companyid);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(Jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accesstokenExpiration,
                CompanyId = companyid
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims, int companyid)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accesstokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims, companyid),
                signingCredentials: signingCredentials
                );
            return jwt;

        }
        private  IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims,int companyid)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentitfier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.Name}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            claims.AddCompany(companyid.ToString());
            return claims;


        }
    }
}