using E_Mutabakat.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.DataAccess.Concrete.EntityFrameWork.Context
{
    public class ContextDb:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-ROTCU0Q;initial catalog=eReconcliations;integrated security=true");
        }
        public DbSet<AccountReconclition> AccountReconclitions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BaBsReconcilition> BaBsReconcilitions { get; set; }
        public DbSet<BaBsReconcilitionsDetail> BabsReconcilitionsDetails { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyAccount> CurrencyAccounts { get; set; }
        public DbSet<MailParameter> MailParameters { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<AccountReconcilitionDetail> AccountReconcilitionDetails { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }
    }
}
