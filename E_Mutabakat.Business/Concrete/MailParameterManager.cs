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
    public class MailParameterManager:IMailParameterService
    {
        private readonly IMailParameterDal _mailParameterDal;

        public MailParameterManager(IMailParameterDal mailParameterDal)
        {
            _mailParameterDal = mailParameterDal;
        }

        public IDataResult<MailParameter> Get(int companyId)
        {
            return new SuccesDataResult<MailParameter>(_mailParameterDal.Get(m =>
            m.CompanyId == companyId
            ));
            
        }

        public IResult Update(MailParameter mailParameter)
        {
            var result = Get(mailParameter.CompanyId);
            if(result.Data==null)
            {
                _mailParameterDal.Add(mailParameter);
            }
            else
            {
                result.Data.Smtp = mailParameter.Smtp;
                result.Data.Port = mailParameter.Port;
                result.Data.Ssl = mailParameter.Ssl;
                result.Data.Email = mailParameter.Email;
                result.Data.Password = mailParameter.Password;
                _mailParameterDal.Update(result.Data);
            }
            return new SuccessResult(Messages.MailParameterAdded);

        }
    }
}
