using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Ultilities.InterCeptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classatribute = type.GetCustomAttributes<MethodIncerceptionBaseAttribute>(true).ToList();
            var methodatribute = type.GetMethod(method.Name).GetCustomAttributes<MethodIncerceptionBaseAttribute>(true);
            classatribute.AddRange(methodatribute);
            return classatribute.OrderBy(x =>x.Priority).ToArray();



        }
    }
}
