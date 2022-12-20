using Castle.DynamicProxy;
using E_Mutabakat.Core.Extensions;
using E_Mutabakat.Core.Ultilities.InterCeptors;
using E_Mutabakat.Core.Ultilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.BusinessAspect
{
  public class SecurityOperation:MethodInterCeption
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextaccessor;
        public SecurityOperation(string roles)
        {
            _roles = roles.Split(",");
            _httpContextaccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextaccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if(roleClaims.Contains(role))
                    {
                    return;
                   }

            }
            throw new Exception("islem yapmaya yetkiniz yok");
}
    }
}
