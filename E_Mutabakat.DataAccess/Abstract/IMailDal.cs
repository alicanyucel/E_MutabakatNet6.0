using E_Mutabakat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.DataAccess.Abstract
{
    public interface IMailDal
    {
        void SendEmail(SendMailDtos sendEmailDtos);

    }
}
