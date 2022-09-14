using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace É_Mutabakat.Core.Ultilities.Result.Abstract
{
    public interface IResult
    {
        public bool Success { get;  }
        public string Message { get;  }

    }
}
