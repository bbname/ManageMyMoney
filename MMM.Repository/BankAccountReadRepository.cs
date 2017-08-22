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

        public override BankAccount GetById(string id)
        {
            var bankAccount = _dbSet.Find(id);
            bankAccount.Transactions = bankAccount.Transactions.OrderByDescending(t => t.SetDate).ToList();
            return bankAccount;
        }

        public IEnumerable<BankAccount> GetBankAccountsByUserId(string userId)
        {
            return _dbSet.AsEnumerable().Where(b => b.User.Id == userId);
        }

        public string GetUserIdByBankAccountId(string bankAccountId)
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

        public bool IsBankAccountCorrect(string bankAccountId, string userId)
        {
            return _dbSet.Any(b => b.Id == bankAccountId && b.User.Id == userId);
        }
    }
}
