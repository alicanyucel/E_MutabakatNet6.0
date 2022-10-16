using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using E_Mutabakat.Business.Abstract;
using E_Mutabakat.Business.Concrete;
using E_Mutabakat.Core.Ultilities.InterCeptors;
using E_Mutabakat.Core.Ultilities.Security.Jwt;
using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.DataAccess.Concrete.EntityFrameWork;
using E_Mutabakat.Entities.Concrete;
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

            builder.RegisterType<AccountReconciliationDetailManager>().As<IAccountReconciliationDetailService>();
            builder.RegisterType<EfAccountReconcilitiaonDetailDal>().As<IAccountReconciliationDetailDal>();

            builder.RegisterType<AccountReconcilitionManager>().As<IAccountReconcliationService>();
            builder.RegisterType<EfAccountReconcitiationDal>().As<IAccountReconciliationDal>();

            builder.RegisterType<BabsReconciliationManager>().As<IBabsReconciliationService>();
            builder.RegisterType<EfBabsReconcliationDal>().As<IBabsReconciliaitonsDal>();

            builder.RegisterType<BabsReconciliationDetailManager>().As<IBabsReconciliationDetailService>();
            builder.RegisterType<EfBabsReconcliationDetailDal>().As<IBabsReconciliationDetailDal>();

            builder.RegisterType<CurrencyAccountManager>().As<ICurrencyAccountService>();
            builder.RegisterType<EfCurrencyAccountDal>().As<ICurrencyAccountDal>();

            builder.RegisterType<CurrencyManager>().As<ICurrencyService>();
            builder.RegisterType<EfCurrencyDal>().As<ICurrencyDal>();

            builder.RegisterType<MailParameterManager>().As<IMailParameterService>();
            builder.RegisterType<EfEmailParameterDal>().As<IMailParameterDal>();

            builder.RegisterType<MailManager>().As<IMailService>();
            builder.RegisterType<EfMailDal>().As<IMailDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<MailTemplateManager>().As<IMailTemplateService>();
            builder.RegisterType<EfMailTemplateDal>().As<IMailTemplateDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelpers>().As<ITokenHelpers>();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }). SingleInstance();
        }
    }
}
