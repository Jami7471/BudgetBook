using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public sealed class BudgetBookContext : DbContext
    {
        public BudgetBookContext(string dataBasePath)
        {
            if (string.IsNullOrWhiteSpace(dataBasePath))
            {
                throw new ArgumentException($"'{nameof(dataBasePath)}' cannot be null or whitespace.", nameof(dataBasePath));
            }

            DataBasePath = dataBasePath;
        }

        public string DataBasePath { get; } = string.Empty;

        public DbSet<AccountEntity>? Accounts { get; set; }

        public DbSet<MoneyPoolEntity>? MoneyPools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>()
                .ToTable("Account")
                .HasKey(a => a.GUID)
                .HasName("PrimaryKey_GUID");

            modelBuilder.Entity<MoneyPoolEntity>()
             .ToTable("MoneyPool")
             .HasKey(a => a.GUID)
             .HasName("PrimaryKey_GUID");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@$"Data Source={DataBasePath};");
        }
    }
}
