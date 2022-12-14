using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public sealed class AccountEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public AccountType Type { get; set; } = AccountType.Undefined;
    }
}
