using E_Mutabakat.DataAccess.Abstract;
using E_Mutabakat.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.DataAccess.Concrete.EntityFrameWork
{
    public class EfMailDal : IMailDal
    {
        public void SendEmail(SendMailDtos sendEmailDtos)
        {
            using (MailMessage mail=new MailMessage())
            {
                mail.From = new MailAddress(sendEmailDtos.mailParameter.Email);
                mail.To.Add(sendEmailDtos.Email);
                mail.Subject = sendEmailDtos.Subject;
                mail.Body = sendEmailDtos.Body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(sendEmailDtos.mailParameter.Smtp))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(sendEmailDtos.mailParameter.Email,sendEmailDtos.mailParameter.Password);
                    smtp.EnableSsl = sendEmailDtos.mailParameter.Ssl;
                    smtp.Send(mail);
                }

            }
        }
    }
}
