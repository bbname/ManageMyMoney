using System.Collections.Generic;
using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IReadBankAccount
    {
        IEnumerable<BankAccount> GetAllBankAccountsByUserId(string userId);
        BankAccount GetBankAccountById(string id);
        string GetUserIdByBankAccountId(string bankAccountId);
        bool IsBankAccountCorrect(string bankAccountId, string userId);
    }
}