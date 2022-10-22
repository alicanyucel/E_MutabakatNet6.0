using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Ultilities.Ioc
{
   public class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IServiceCollection Create(IServiceCollection service)

        {
            ServiceProvider = service.BuildServiceProvider();
            return service;
        }
    }
}
