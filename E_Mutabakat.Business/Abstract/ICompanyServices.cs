using É_Mutabakat.Core.Ultilities.Result.Abstract;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Abstract
{
    public interface ICompanyServices
    {
      IResult Add(Company company);

      IDataResult<List<Company> >GetList();
        IResult CompanyExists(Company company);
        IResult UserCompanyAdd(int userid,int companyid);


    }
}
