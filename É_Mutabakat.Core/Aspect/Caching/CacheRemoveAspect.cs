using Castle.DynamicProxy;
using E_Mutabakat.Core.CrossCuttingConcerns.Caching;
using E_Mutabakat.Core.Ultilities.InterCeptors;
using E_Mutabakat.Core.Ultilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Aspect.Caching
{
   public class CacheRemoveAspect:MethodInterCeption
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string v)
        {
            V = v;
        }

        public CacheRemoveAspect(string pattern, ICacheManager cacheManager)
        {
            _pattern = pattern;
            _cacheManager =ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public string V { get; }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
