using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Constans;
using E_Mutabakat.Business.ValidationRules.FluentValidation;
using E_Mutabakat.Core.Aspect.Autofac.Validation;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.DataAccess.Concrete.EntityFrameWork;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
    public class CompanyManager : ICompanyServices
    {
        /*
        KULLANICI YETKİLERİ
        validation
        Transaction
        loglama için business katmanı kullanıyoruz
        */
        private readonly ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }
        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Add(Company company)
        {

            _companyDal.Add(company);
            return new SuccessResult(Messages.AddCompany);
        }

        public IResult CompanyExists(Company company)
        {
            var result = _companyDal.Get(c => c.Name == company.Name && c.TaxDepartment == company.TaxDepartment && c.TaxIdNumber == company.TaxIdNumber && c.IdentityNumber == company.IdentityNumber);
            if(result!=null)
            {
                return new ErrorResult(Messages.CompanyAllReadyExists);
            }
            return new SuccessResult();

        }

        public IDataResult<UserCompany> GetCompany(int userid)
        {
            return new SuccesDataResult<UserCompany>(_companyDal.GetCompany(userid));
        }

        public IDataResult<List<Company>> GetList()
        {

            return new SuccesDataResult<List<Company>>(_companyDal.GetList());
        }

        public IResult UserCompanyAdd(int userid, int companyid)
        {

            _companyDal.UserCompanyAdd(userid,companyid);
            return new SuccessResult();

        }
    }
}
