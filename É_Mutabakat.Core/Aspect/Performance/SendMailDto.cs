using Castle.DynamicProxy;
using E_Mutabakat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Aspect.Performance
{
   public class SendMailDto
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string SMTP { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}
