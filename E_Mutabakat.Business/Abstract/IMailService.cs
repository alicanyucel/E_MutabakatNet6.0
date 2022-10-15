using É_Mutabakat.Core.Ultilities.Result.Abstract;
using E_Mutabakat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Abstract
{
    public interface IMailService
    {
        IResult SendEmail(SendMailDtos sendMailDtos);
    }
}
