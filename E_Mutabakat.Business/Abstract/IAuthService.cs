using É_Mutabakat.Core.Ultilities.Result.Abstract;
using E_Mutabakat.Core.Ultilities.Security.Jwt;
using E_Mutabakat.Entities.Concrete;
using E_Mutabakat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegister, string password,Company company);
        IDataResult<User> RegisterSecondAccount(UserForRegisterDto userForRegister, string password);
        IDataResult<User> Login(UserForLoginDto userForLogin);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user,int companyid);
        IResult CompanyExists(Company company);


    }
}
