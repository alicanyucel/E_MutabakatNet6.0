using E_Mutabakat.Business.Abstract;
using E_Mutabakat.DataAccess.Abstract;
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

        public List<Company> GetList()
        {
            return _companyDal.GetList();
        }
    }
}
