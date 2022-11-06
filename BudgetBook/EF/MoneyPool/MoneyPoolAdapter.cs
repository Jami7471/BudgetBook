using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public sealed class MoneyPoolAdapter : BaseAdapter
    {
        public MoneyPoolAdapter(BudgetBookContext context) : base(context)
        {

        }

        public override MoneyPoolEntity? Select(string guid)
        {
            return Context?.MoneyPools?.ToList().FirstOrDefault(MoneyPool => MoneyPool.GUID.Equals(guid));
        }

        public List<MoneyPoolEntity>? SelectAll()
        {
            Microsoft.EntityFrameworkCore.DbSet<MoneyPoolEntity>? datas = Context?.MoneyPools;

            if (datas != null && datas.Any())
            {
                return datas.ToList();
            }
            else
            {
                return new List<MoneyPoolEntity>();
            }
        }

        public bool Insert(MoneyPoolEntity moneyPoolEntity)
        {
            if (Context.MoneyPools == null)
            {
                return false;
            }

            if (moneyPoolEntity.DateOfBalance != null)
            {
                throw new ArgumentNullException(nameof(moneyPoolEntity.DateOfBalance));
            }

            if (moneyPoolEntity.Account != null)
            {
                throw new ArgumentNullException(nameof(moneyPoolEntity.Account));
            }

            DateTimeOffset now = DateTimeOffset.Now;
            moneyPoolEntity.Creation = now;
            moneyPoolEntity.LastModified = now;

            try
            {
                Context.Database.BeginTransaction();

                Context.MoneyPools.Add(moneyPoolEntity);
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

        public bool Update(MoneyPoolEntity moneyPoolEntity)
        {
            if (Context.MoneyPools == null)
            {
                return false;
            }

            moneyPoolEntity.LastModified = DateTime.Now;

            try
            {
                Context.Database.BeginTransaction();

                Context.MoneyPools.Update(moneyPoolEntity);
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

        public bool Delete(MoneyPoolEntity moneyPoolEntity)
        {
            if (Context.MoneyPools == null)
            {
                return false;
            }

            try
            {
                Context.Database.BeginTransaction();

                Context.MoneyPools.Remove(moneyPoolEntity);
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
