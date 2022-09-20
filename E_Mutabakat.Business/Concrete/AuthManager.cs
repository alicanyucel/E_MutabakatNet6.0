using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Constans;
using E_Mutabakat.Core.Ultilities.Hashing;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.Core.Ultilities.Security.Jwt;
using E_Mutabakat.Entities.Concrete;
using E_Mutabakat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelpers _tokenHelpers;
        private readonly IUserService _userService;
        public AuthManager(IUserService userService,ITokenHelpers tokenHelpers)
        {
            _userService = userService;
            _tokenHelpers = tokenHelpers;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user,int companyid)
        {
            var claims = _userService.GetClaims(user,companyid);
            var accesstoken = _tokenHelpers.CreateToken(user, claims, companyid);
            return new SuccesDataResult<AccessToken>(accesstoken);

        }

        public IDataResult<User> Login(UserForLoginDto userForLogin)
        {
            var userToCheck = _userService.GetByMail(userForLogin.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccesDataResult<User>(userToCheck, Messages.SuccessfulLogin);

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegister, string password)
        {
            // bunları encoidng hamcsha512 ile alacaz veri tabanında
            byte[] passwordHash, passwordsalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordsalt);
            var user = new User
            {
                Email = userForRegister.Email,
                AddedAt=DateTime.Now,
                IsActive = true,
                MailConfirm = false,
                MailConfirmDate = DateTime.Now,
                MailConfirmValue = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordsalt,
                Name = userForRegister.Name

            };

            _userService.Add(user);
            return new SuccesDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
           if(_userService.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
