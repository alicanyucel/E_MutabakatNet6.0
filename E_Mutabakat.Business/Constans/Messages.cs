using Castle.DynamicProxy;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Constans
{
    public class Messages
    {
        public static string UpdateUserOperationClaim = "User Operation Claim Güncellendi";
        public static string DeletedUserOperationClaim = "User Operation Claim Silindi";
        public static string AddUserOperationClaim = "User Operation Claim Eklendi";
        public static string DeletedOperationClaim = "operation claim silindi";
        public  static string UpdatedOperationClaim="operation claim güncellendi";
        public static string AddedOperationClaim = " operation claim eklendi";
        public static string AddedBabsReconciliationDetail = "babs mutabakat detayı eklendi";
        public static string DeletedBabsReconciliationDetail = "babs mutabakatı detayı silindi";
        public static string UpdatedBabsReconciliationDetail = "babs mutabakatı detayı güncellendi";
        public static string DeletedBabsReconciliation = "babs mutabakatı silindi";
        public static string UpdatedBabsReconciliation = "babs mutabakatı güncellendi";
        public static string AddedBabsReconciliation = "babs mutabakatı eklendi";
        public static string AddedAccountReconciliationDetail = "Cari mutabakat detayı eklendi";
        public static string UpdateAccountReconciliationDetail = "Cari mutabakat deayı güncellendi";
        public static string DeleteAccountReconciliationDetail = "Cari mutabakat detayi silindi";
        public static string DeleteAccountReconciliation = "Cari mutabakat kaydi silindi";
        public static string UpdateAccountReconciliation = "cari mutabakat kaydi guncellendi";
        public static string AddAccountReconciliatian = "cari mutabakat kaydi eklendi";
        public static string DeleteCurrencyAccount = "cari kaydı başarıyla silindi";
        public static string UpdateCurrencyAccount = "cari kaydı basariyla guncellendi";
        public static string AddedCurrencyAccount = "Cari kaydı başarıyla yapildi";
        public static string UpdateCompany = "şirket bilgileri guncellendi";
        public static string MailConfirmTİmeHasNotExpired = "mail onayini 5 dk da bir gönderebiliriz";
        public static string MailAlreadyConfirm = "mailiniz zaten onaylanmistir tekrar gonderim yapilmadi";
        public static string MailConfirmSendSuccessfull = "maik dogrulaması basarıyla gonderildi";
        public static string UserMailConfirmSuccesfull = "mailiniz basariyla onaylandi";
        public static string MailTemplateUpdated = "mesaj guncellendi";
        public static string MailTemplateDeleted = "mesaj silindi";
        public static string MailTemplateAdded = "mesaj eklendi";
        public static string MailSendSuccesfull = "mesaj gonderildi";
        public static string AddCompany = "sirket kaydi basarili olarak yapildi";
        public static string UserAlreadyExists = "kullanııc zaten var";
        public static string UserNotFound = "Kullanıcı yok";
        public static string SuccessfulLogin = "login basarili";
        public static string PasswordError = "Parola hatali";
        public static string UserRegistered = "kullanıcı kaydı basarıili";
        public static string CompanyAllReadyExists = "Sirket zatan kayitli";
        public static string MailParameterAdded = "Mail Parametreleri eklendi";
    }
}
