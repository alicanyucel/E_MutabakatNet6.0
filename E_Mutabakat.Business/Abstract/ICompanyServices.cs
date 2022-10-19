using É_Mutabakat.Core.Ultilities.Result.Abstract;
using E_Mutabakat.Entities.Concrete;
using E_Mutabakat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Abstract
{
    public interface ICompanyServices
    {
        IDataResult<Company> GetById(int id);
        IResult Update(Company company);
      IResult Add(Company company);
        IResult AddCompanyAndUserCompany(CompanyDto companyDto);
      IDataResult<List<Company> >GetList();
        IResult CompanyExists(Company company);
        IResult UserCompanyAdd(int userid,int companyid);
        IDataResult<UserCompany> GetCompany(int userid);

    }
}
