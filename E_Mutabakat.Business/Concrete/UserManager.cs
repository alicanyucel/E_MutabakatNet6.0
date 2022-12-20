using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.ValidationRules.FluentValidation;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.Entities.Concrete;
using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Mutabakat.Core.Aspect.Autofac.Validation;
using E_Mutabakat.Core.Aspect.Caching;
using E_Mutabakat.Core.Aspect.Performance;
using E_Mutabakat.Business.BusinessAspect;

namespace E_Mutabakat.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ CacheRemoveAspect("IUserService.Get")]
        [ValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {
           
            _userDal.Add(user);
        }
        [CacheAspect(60)]
        public User GetById(int id)
        {
            return _userDal.Get(u=>u.Id==id);
        }
        [CacheAspect(60)]
        public User GetByMail(string email)
        {
            return _userDal.Get(p => p.Email == email);
        }

        [CacheAspect(60)]
        public User GetByMailConfirmValue(string value)
        {
            return _userDal.Get(p => p.MailConfirmValue == value);
        }
        [CacheAspect(60)]
        public List<OperationClaim> GetClaims(User user,int companyid)
        {
            return _userDal.GetClaims(user, companyid);
        }
        [PerformanceAspect(3)]
        [SecurityOperation("User.Update,Admin.Admin")]
        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
