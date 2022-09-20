using É_Mutabakat.Core.Ultilities.Result.Abstract;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Abstract
{
    public interface IMailParameterService
    {
        IResult Update(MailParameter mailParameter);
        IDataResult<MailParameter> Get(int companyId);
         
    }
}
