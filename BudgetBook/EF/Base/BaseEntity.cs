using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public class BaseEntity
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();

        public DateTimeOffset Creation { get; set; } = DateTimeOffset.MinValue;

        public DateTimeOffset LastModified { get; set; } = DateTimeOffset.MinValue;
    }
}
