using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Constans;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
   public class AccountReconciliationDetailManager:IAccountReconciliationDetailService
    {
        private readonly IAccountReconciliationDetailDal _accountReconciliationDetailDal;

        public AccountReconciliationDetailManager(IAccountReconciliationDetailDal accountReconciliationDetailDal)
        {
            _accountReconciliationDetailDal = accountReconciliationDetailDal;
        }

        public IResult Add(AccountReconcilitionDetail accountReconciliationDetail)
        {
            _accountReconciliationDetailDal.Add(accountReconciliationDetail);
            return new SuccessResult(Messages.AddedAccountReconciliationDetail);
        }

        public IResult AddExcel(string filepath, int companyId)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(AccountReconcilitionDetail accountReconclitionDetail)
        {
            _accountReconciliationDetailDal.Delete(accountReconclitionDetail);
            return new SuccessResult(Messages.DeleteAccountReconciliationDetail);
        }

        public IDataResult<AccountReconcilitionDetail> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<AccountReconcilitionDetail>> GetList(int companyid)
        {
            throw new NotImplementedException();
        }

        public IResult Update(AccountReconcilitionDetail accountReconclitionDetail)
        {
            _accountReconciliationDetailDal.Update(accountReconclitionDetail);
            return new SuccessResult(Messages.UpdateAccountReconciliationDetail);
        }
    }
}
