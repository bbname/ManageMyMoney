using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMM.Model;

namespace MMM.Repository.Interfaces
{
    public interface IBankAccountReadRepository : IReadRepository<BankAccount>
    {
        IEnumerable<BankAccount> GetBankAccountsByUserId(string userId);
        string GetUserIdByBankAccountId(string bankAccountId);
        bool IsBankAccountCorrect(string bankAccountId, string userId);
    }
}
