using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public sealed class AccountAdapter : BaseAdapter
    {
        public AccountAdapter(BudgetBookContext context) : base(context)
        {

        }

        public override AccountEntity? Select(string guid)
        {
            return Context?.Accounts?.ToList().FirstOrDefault(account => account.GUID.Equals(guid));
        }

        public List<AccountEntity>? SelectAll()
        {
            Microsoft.EntityFrameworkCore.DbSet<AccountEntity>? datas = Context?.Accounts;

            if (datas != null && datas.Any())
            {
                return datas.ToList();
            }
            else
            {
                return new List<AccountEntity>();
            }
        }

        public bool Insert(AccountEntity accountEntity)
        {
            if (Context.Accounts == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(accountEntity.Name))
            {
                throw new ArgumentNullException(nameof(accountEntity.Name));
            }

            DateTimeOffset now = DateTimeOffset.Now;
            accountEntity.Creation = now;
            accountEntity.LastModified = now;

            try
            {
                Context.Database.BeginTransaction();

                Context.Accounts.Add(accountEntity);
                Context.SaveChanges();

                Context.Database.CommitTransaction();
            }
            catch
            {
                Context.Database.RollbackTransaction();
                throw;
            }

            return true;
        }

        public bool Update(AccountEntity accountEntity)
        {
            if (Context.Accounts == null)
            {
                return false;
            }

            accountEntity.LastModified = DateTime.Now;

            try
            {
                Context.Database.BeginTransaction();

                Context.Accounts.Update(accountEntity);
                Context.SaveChanges();

                Context.Database.CommitTransaction();
                return true;
            }
            catch
            {
                Context.Database.RollbackTransaction();
                throw;
            }
        }

        public bool Delete(AccountEntity accountEntity)
        {
            if (Context.Accounts == null)
            {
                return false;
            }

            try
            {
                Context.Database.BeginTransaction();

                Context.Accounts.Remove(accountEntity);
                Context.SaveChanges();

                Context.Database.CommitTransaction();
            }
            catch
            {
                Context.Database.RollbackTransaction();
                throw;
            }

            return true;
        }
    }
}
