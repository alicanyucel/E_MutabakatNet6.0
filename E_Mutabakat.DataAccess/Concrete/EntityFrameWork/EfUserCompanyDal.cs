using É_Mutabakat.Core.DataAccess.EntityFramework;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.DataAccess.Concrete.EntityFrameWork.Context;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.DataAccess.Concrete.EntityFrameWork
{
    public class EfUserCompanyDal:EfEntityFrameworkBase<UserCompany,ContextDb>,IUserCompanyDal
    {
    }
}
