using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Constans;
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

        public IResult Add(Company company)
        {

            _companyDal.Add(company);
            return new SuccessResult(Messages.AddCompany);
        }

        public  IDataResult<List<Company>>GetList()
        {

            return new SuccesDataResult<List<Company>>(_companyDal.GetList());
        }

      
    }
}
