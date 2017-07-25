using System.Collections.Generic;
using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IReadBankAccount
    {
        IEnumerable<Account> GetAllBankAccountsByUserId(string userId);
        Account GetAccountById(int id);
        string GetUserIdByBankAccountId(int bankAccountId);
    }
}