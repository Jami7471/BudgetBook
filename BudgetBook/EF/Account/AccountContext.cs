using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public sealed class AccountContext : BaseContext
    {
        public AccountContext(string dataBasePath) : base(dataBasePath)
        {

        }

        public DbSet<AccountEntity>? Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>()
                .ToTable("Account")
                .HasKey(a => a.GUID)
                .HasName("PrimaryKey_GUID");
        }      
    }
}
