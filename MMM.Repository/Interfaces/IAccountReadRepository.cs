using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMM.Model;

namespace MMM.Repository.Interfaces
{
    public interface IAccountReadRepository : IReadRepository<Account>
    {
        IEnumerable<Account> GetBankAccountsByUserId(string userId);
        string GetUserIdByBankAccountId(int bankAccountId);
        bool IsBankAccountCorrect(int id, string userId);
    }
}
