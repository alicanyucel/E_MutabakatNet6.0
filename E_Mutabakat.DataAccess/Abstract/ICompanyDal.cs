using É_Mutabakat.Core.DataAccess;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.DataAccess.Abstract
{
public interface ICompanyDal:IEntityRepository<Company>
    {

        void UserCompanyAdd(int userid,int companyid);
    }
}
