using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Ultilities.Ioc
{
    public interface ICoreModule
    {
        void Load(IServiceCollection service);
    }
}
