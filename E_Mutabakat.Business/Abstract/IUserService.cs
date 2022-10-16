using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user,int companyid);
        void Add(User user);
        User GetByMail(string email);
        User GetByMailConfirmValue(string value);
        void Update(User user);
        User GetById(int id);
    }
}
