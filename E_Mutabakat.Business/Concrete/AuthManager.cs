using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Constans;
using E_Mutabakat.Business.ValidationRules.FluentValidation;
using E_Mutabakat.Core.CrossCuttingConcerns.Validation;
using E_Mutabakat.Core.Ultilities.Hashing;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.Core.Ultilities.Security.Jwt;
using E_Mutabakat.Entities.Concrete;
using E_Mutabakat.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IMailService _mailService;
        private readonly IMailParameterService _mailParameterService;
        private readonly ICompanyServices _companyservice;
        private readonly ITokenHelpers _tokenHelpers;
        private readonly IUserService _userService;
        public AuthManager(IUserService userService,ITokenHelpers tokenHelpers, ICompanyServices companyservice,IMailService mailService,IMailParameterService mailParameterService)
        {
            _mailService =mailService;
            _mailParameterService = mailParameterService;
            _userService = userService;
            _tokenHelpers = tokenHelpers;
            _companyservice = companyservice;
        }

        public IResult CompanyExists(Company company)
        {
          var result=_companyservice.CompanyExists(company);
            if(result.Success==false)
            {
                return new ErrorResult(Messages.CompanyAllReadyExists);

            }
            return new SuccessResult();
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

        public IDataResult<UserCompanyDto> Register(UserForRegisterDto userForRegister, string password,Company company)
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
            ValidationTool.Validate(new UserValidator(),user);
            ValidationTool.Validate(new CompanyValidator(), company);

            _userService.Add(user);
            _companyservice.Add(company);
            _companyservice.UserCompanyAdd(user.Id,company.Id);
            UserCompanyDto userCompanyDto = new UserCompanyDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                AddedAt = user.AddedAt,
                companyid = company.Id,
                IsActive = true,
                MailConfirm = user.MailConfirm,
                MailConfirmDate = user.MailConfirmDate,
                MailConfirmValue = user.MailConfirmValue,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };
            var mailparameter = _mailParameterService.Get(4);
            SendMailDtos sendMailDtos = new SendMailDtos()
            {
                mailParameter = mailparameter.Data,
                Email = user.Email,
                Subject="kullanıcı onay maili",
                Body="kullanici sisteme kayit oldu.Kaydı tamamlamak icin asagidaki linke tıklayiniz"
                
            };
            _mailService.SendEmail(sendMailDtos);

            return new SuccesDataResult<UserCompanyDto>(userCompanyDto, Messages.UserRegistered);

        }

        public IDataResult<User> RegisterSecondAccount(UserForRegisterDto userForRegister, string password)
        {
            byte[] passwordHash, passwordsalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordsalt);
            var user = new User
            {
                Email = userForRegister.Email,
                AddedAt = DateTime.Now,
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
