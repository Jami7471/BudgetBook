using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public class BaseContext : DbContext
    {
        public BaseContext(string dataBasePath)
        {
            if (string.IsNullOrWhiteSpace(dataBasePath))
            {
                throw new ArgumentException($"'{nameof(dataBasePath)}' cannot be null or whitespace.", nameof(dataBasePath));
            }

            DataBasePath = dataBasePath;
        }

        public string DataBasePath { get; } = string.Empty;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@$"Data Source={DataBasePath};");
        }

    }
}
