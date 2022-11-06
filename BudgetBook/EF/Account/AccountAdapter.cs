using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook
{
    public sealed class AccountAdapter : BaseAdapter
    {
        public AccountAdapter(AccountContext context) : base(context)
        {
           
        }    

        public override AccountEntity? Select(string guid)
        {
            if (Context is AccountContext accountContext)
            {
                return accountContext?.Accounts?.ToList().FirstOrDefault(account => account.GUID.Equals(guid));
            }
            else
            {
                return null;
            }              
        }

        public List<AccountEntity>? SelectAll()
        {
            if (Context is AccountContext accountContext)
            {
                Microsoft.EntityFrameworkCore.DbSet<AccountEntity>? datas = accountContext?.Accounts;

                if (datas != null && datas.Any())
                {
                    return datas.ToList();
                }
                else
                {
                    return new List<AccountEntity>();
                }
            }

            return null;
        }       

        public bool Insert(AccountEntity accountEntity)
        {
            if (Context is AccountContext accountContext)
            {
                if (accountContext.Accounts == null)
                {
                    return false;
                }

                if(string.IsNullOrWhiteSpace(accountEntity.Name))
                {
                    throw new ArgumentNullException(nameof(accountEntity.Name));
                }

                DateTimeOffset now = DateTimeOffset.Now;
                accountEntity.Creation = now;
                accountEntity.LastModified = now;

                try
                {
                    accountContext.Database.BeginTransaction();

                    accountContext.Accounts.Add(accountEntity);
                    accountContext.SaveChanges();

                    accountContext.Database.CommitTransaction();
                }
                catch
                {
                    accountContext.Database.RollbackTransaction();
                    throw;
                }

                return true;
            }
            else
            {
                return false;
            }          
        }

        public bool Update(AccountEntity accountEntity)
        {
            if (Context is AccountContext accountContext)
            {
                if (accountContext.Accounts == null)
                {
                    return false;
                }

                accountEntity.LastModified = DateTime.Now;

                try
                {
                    accountContext.Database.BeginTransaction();

                    accountContext.Accounts.Update(accountEntity);
                    accountContext.SaveChanges();

                    accountContext.Database.CommitTransaction();
                    return true;
                }
                catch
                {
                    accountContext.Database.RollbackTransaction();
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Delete(AccountEntity accountEntity)
        {
            if (Context is AccountContext accountContext)
            {
                if (accountContext.Accounts == null)
                {
                    return false;
                }

                try
                {
                    accountContext.Database.BeginTransaction();

                    accountContext.Accounts.Remove(accountEntity);
                    accountContext.SaveChanges();                  

                    accountContext.Database.CommitTransaction();            
                }
                catch
                {
                    accountContext.Database.RollbackTransaction();
                    throw;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
