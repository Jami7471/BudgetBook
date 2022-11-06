using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public class BaseAdapter : IDisposable
    {
        public BaseAdapter(BudgetBookContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        ~BaseAdapter()
        {
            Dispose();
        }

        private bool _disposedValue;

        public BudgetBookContext Context { get; private set; }


        public void Dispose()
        {
            if (_disposedValue == false)
            {
                Context?.Dispose();
                GC.SuppressFinalize(this);
                _disposedValue = true;
            }
        }

        public virtual BaseEntity? Select(string guid)
        {
            return null;
        }

        public bool Insert(BaseEntity baseEntity)
        {
            return false;

        }

        public bool Update(BaseEntity baseEntity)
        {
            return false;
        }

        public bool Delete(BaseEntity baseEntity)
        {
            return false;
        }
    }
}
