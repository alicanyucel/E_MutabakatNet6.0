using E_Mutabakat.Core.Ultilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.DependencyResolvers
{
   public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddMemoryCache();
        }
    }
}
