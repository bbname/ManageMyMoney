using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMM.Model;
using MMM.Repository.Interfaces;

namespace MMM.Repository
{
    public class BankAccountReadRepository : ReadRepository<BankAccount>, IBankAccountReadRepository
    {
        public BankAccountReadRepository(DbContext ctx) : base(ctx)
        {
            
        }

        public override BankAccount GetById(int id)
        {
            var account = _dbSet.Find(id);
            account.Transactions = account.Transactions.OrderByDescending(t => t.SetDate).ToList();
            return account;
        }

        public IEnumerable<BankAccount> GetBankAccountsByUserId(string userId)
        {
            return _dbSet.AsEnumerable().Where(b => b.User.Id == userId);
        }

        public string GetUserIdByBankAccountId(int bankAccountId)
        {
            try
            {
                return _dbSet.FirstOrDefault(b => b.Id == bankAccountId).User.Id;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Brak danych w bazie.");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public bool IsBankAccountCorrect(int id, string userId)
        {
            return _dbSet.Any(b => b.Id == id && b.User.Id == userId);
        }
    }
}
