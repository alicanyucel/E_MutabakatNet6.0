using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Constans;
using É_Mutabakat.Core.Ultilities.Result.Abstract;
using É_Mutabakat.Core.Ultilities.Result.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
    public class MailManager : IMailService
    {
        private readonly IMailDal _mailDal;
        public MailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public IResult SendEmail(SendMailDtos sendEmailDtos)
        {
            _mailDal.SendEmail(sendEmailDtos);
            return new SuccessResult(Messages.MailSendSuccesfull);
        }
    }
}
