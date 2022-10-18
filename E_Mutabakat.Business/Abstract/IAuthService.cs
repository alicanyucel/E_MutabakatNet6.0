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
        IDataResult<UserCompany> GetCompany(int userid);
        IDataResult<UserCompanyDto> Register(UserForRegisterDto userForRegister, string password,Company company);
        IDataResult<User> RegisterSecondAccount(UserForRegisterDto userForRegister, string password,int companyid);
        IDataResult<User> Login(UserForLoginDto userForLogin);
        IDataResult<User> GetByMailConfirmValue(string value);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user,int companyid);
        IResult CompanyExists(Company company);
        IResult Update(User user);
        IDataResult<User> GetById(int id);
        IResult SentConfirmEmail(User user);
    }
}
