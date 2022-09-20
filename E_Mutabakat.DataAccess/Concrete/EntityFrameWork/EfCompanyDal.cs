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
    public class EfCompanyDal : EfEntityFrameworkBase<Company, ContextDb>, ICompanyDal
    {
        public void UserCompanyAdd(int userid, int companyid)
        {
            using (var context=new ContextDb())
            {
                UserCompany userCompany = new UserCompany()
                {
                    UserId = userid,
                    CompanyId = companyid,
                    AddedAt = DateTime.Now,
                    IsActive = true,

                };
                context.UserCompanies.Add(userCompany);

            }
        }
    }
}
