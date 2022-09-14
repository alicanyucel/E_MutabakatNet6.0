using Autofac;
using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Concrete;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.DataAccess.Concrete.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManager>().As<ICompanyServices>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

        }
    }
}
