using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace E_Mutabakat.Core.Ultilities.InterCeptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple =true,Inherited =true) ]
   public class MethodIncerceptionBaseAttribute:Attribute,IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation ınvocation)
        {


        }
    }
}
