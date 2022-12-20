using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.BusinessAspect;
using E_Mutabakat.Business.Constans;
using E_Mutabakat.Core.Aspect.Caching;
using E_Mutabakat.Core.Aspect.Performance;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.DataAccess.Concrete.EntityFrameWork;
using E_Mutabakat.Entities.Concrete;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
    public class AccountReconciliationDetailManager : IAccountReconciliationDetailService
    {
        private readonly IAccountReconciliationDetailDal _accountReconciliationDetailDal;

        public AccountReconciliationDetailManager(IAccountReconciliationDetailDal accountReconciliationDetailDal)
        {
            _accountReconciliationDetailDal = accountReconciliationDetailDal;
        }
        [PerformanceAspect(3)]
        [SecurityOperation("AccountReconcilitionDetail.Add,Admin")]
        [CacheRemoveAspect("AccountReconcilitionDetail.Get")]

        public IResult Add(AccountReconcilitionDetail accountReconciliationDetail)
        {
            _accountReconciliationDetailDal.Add(accountReconciliationDetail);
            return new SuccessResult(Messages.AddedAccountReconciliationDetail);
        }

        public IResult AddExcel(string filepath, int accountReconciliationId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(filepath, FileMode.Open, FileAccess.Read))
            {//
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string description = reader.GetString(1);

                        if (description != "Açıklama" && description != null)

                        {
                            string date = Convert.ToDateTime(reader.GetValue(0)).ToString("dd/MM/yyyy");

                            string currencyid = reader.GetValue(2).ToString();
                            string debit = reader.GetValue(3).ToString();
                            string credit = reader.GetValue(4).ToString();
                            AccountReconcilitionDetail accountReconcilitionDetail = new AccountReconcilitionDetail()
                            {
                                AccountReconciliationsId = accountReconciliationId,
                                Description = description,
                                Date = Convert.ToDateTime(date),
                                CurrencyCredit = Convert.ToDecimal(credit),
                                CurrencyDebit = Convert.ToDecimal(debit),
                                CurrencyId = Convert.ToInt16(currencyid)

                            };

                            _accountReconciliationDetailDal.Add(accountReconcilitionDetail);



                        }
                    }
                }
            }
            return new SuccessResult(Messages.AddedAccountReconciliationDetail);
        }
    
        public IResult Delete(AccountReconcilitionDetail accountReconclitionDetail)
        {
            _accountReconciliationDetailDal.Delete(accountReconclitionDetail);
            return new SuccessResult(Messages.DeleteAccountReconciliationDetail);
        }

        public IDataResult<AccountReconcilitionDetail> GetById(int id)
        {
            return new SuccesDataResult<AccountReconcilitionDetail>(_accountReconciliationDetailDal.Get(p => p.Id == id));
        }

        public IDataResult<List<AccountReconcilitionDetail>> GetList(int arId)
        {
            return new SuccesDataResult<List<AccountReconcilitionDetail>>(_accountReconciliationDetailDal.GetList(p => p.AccountReconciliationsId == arId));
        }

        public IResult Update(AccountReconcilitionDetail accountReconclitionDetail)
        {
            _accountReconciliationDetailDal.Update(accountReconclitionDetail);
            return new SuccessResult(Messages.UpdateAccountReconciliationDetail);
        }
    }
}