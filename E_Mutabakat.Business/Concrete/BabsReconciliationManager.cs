using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Constans;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.Entities.Concrete;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
    public class BabsReconciliationManager : IBabsReconciliationService
    {
        private readonly IMailService _mailService;
        private readonly IMailTemplateService _mailTemplateService;
        private readonly IMailParameterService _mailParameterService;
        private readonly ICurrencyAccountService _crservice;
        private readonly IBabsReconciliaitonsDal _babsdal;
        public BabsReconciliationManager(IBabsReconciliaitonsDal babsReconciliaitonsDal)
        {
            

            _babsdal = babsReconciliaitonsDal;
        }

        public IResult Add(BaBsReconcilition baBsReconcilition)
        {
            
           

            _babsdal.Add(baBsReconcilition);
            return new SuccessResult(Messages.AddedBabsReconciliation);
        }

        public IResult AddExcel(string filepath, int companyId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(filepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);

                        if (code != "Cari Kodu" && code != null)
                        {
                            string type = reader.GetString(1);
                            double mounth = reader.GetDouble(2);
                            double year = reader.GetDouble(3);
                            double quantit = reader.GetDouble(4);
                            double total = reader.GetDouble(5);
                            
                            //int currencyAccountId = _crservice.GetByCode(code, companyId).Data.Id;

                            BaBsReconcilition baBsReconciliation = new BaBsReconcilition()
                            {
                                CompanyId = companyId,
                               // CurrencyAccountId = currencyAccountId,
                                Type = type,
                                Mounth = Convert.ToInt16(mounth),
                                Year = Convert.ToInt16(year),
                                Quantity = Convert.ToInt16(quantit),
                                Total = Convert.ToDecimal(total)
                                
                            };

                            _babsdal.Add(baBsReconciliation);
                        }
                    }
                }
            }

            File.Delete(filepath);

            return new SuccessResult(Messages.AddedBabsReconciliation);
        }


        public IResult Delete(BaBsReconcilition baBsReconcilition)
        {
            _babsdal.Delete(baBsReconcilition);
            return new SuccessResult(Messages.DeletedBabsReconciliation);
        }

        public IDataResult<BaBsReconcilition> GetById(int id)
        {
            return new SuccesDataResult<BaBsReconcilition>(_babsdal.Get(p => p.Id == id));
        }
    

        public IDataResult<List<BaBsReconcilition>> GetList(int companyid)
        {
        return new SuccesDataResult<List<BaBsReconcilition>>(_babsdal.GetList(p => p.CompanyId == companyid));

        }

        public IResult Update(BaBsReconcilition baBsReconcilition)
        {
           _babsdal.Update(baBsReconcilition);
            return new SuccessResult(Messages.UpdatedBabsReconciliation);
        }
    }
}