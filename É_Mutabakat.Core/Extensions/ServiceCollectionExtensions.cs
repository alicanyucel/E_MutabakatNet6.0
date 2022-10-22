using E_Mutabakat.Core.Ultilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection service, ICoreModule[] modules)
        {
            foreach(var module in modules)
            {
                module.Load(service);
            }
            return ServiceTool.Create(service);
        }
    }
}
