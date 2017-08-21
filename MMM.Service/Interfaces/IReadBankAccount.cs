using System.Collections.Generic;
using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IReadBankAccount
    {
        IEnumerable<BankAccount> GetAllBankAccountsByUserId(string userId);
        BankAccount GetAccountById(int id);
        string GetUserIdByBankAccountId(int bankAccountId);
        bool IsBankAccountCorrect(int id, string userId);
    }
}