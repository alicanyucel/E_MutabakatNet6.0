using E_Mutabakat.Core.Ultilities.InterCeptors;
using System;
using Castle.DynamicProxy;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace E_Mutabakat.Core.Aspect.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterCeption
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionscope=new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionscope.Complete();
                }
                catch (Exception)
                {
                    transactionscope.Dispose();

                    throw;
                }
            }
        }
    }
}
