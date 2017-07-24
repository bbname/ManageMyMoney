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
    public class AccountReadRepository : ReadRepository<Account>, IAccountReadRepository
    {
        public AccountReadRepository(DbContext ctx) : base(ctx)
        {
            
        }

        public IEnumerable<Account> GetBankAccountsByUserId(string userId)
        {
            return _dbSet.AsEnumerable().Where(b => b.User.Id == userId);
        }
    }
}
