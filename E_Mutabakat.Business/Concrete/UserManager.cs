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

namespace E_Mutabakat.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
           
            _userDal.Add(user);
        }

        public User GetById(int id)
        {
            return _userDal.Get(u=>u.Id==id);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(p => p.Email == email);
        }

        public User GetByMailConfirmValue(string value)
        {
            return _userDal.Get(p => p.MailConfirmValue == value);
        }

        public List<OperationClaim> GetClaims(User user,int companyid)
        {
            return _userDal.GetClaims(user, companyid);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
