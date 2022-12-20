using E_Mutabakat.Core.CrossCuttingConcerns.Caching;
using E_Mutabakat.Core.Ultilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.DependencyResolvers
{
   public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection service)
        {
            service.AddSingleton<Stopwatch>();
            service.AddMemoryCache();
            service.AddSingleton<ICacheManager, MemoryCacheManager>();
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
