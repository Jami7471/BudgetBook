using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public sealed class MoneyPoolEntity : BaseEntity
    {
        public decimal Balance { get; set; } = 0;

        public DateTimeOffset? DateOfBalance;

        [ForeignKey("GUID")]
        public AccountEntity? Account { get; set; }
    }
}
