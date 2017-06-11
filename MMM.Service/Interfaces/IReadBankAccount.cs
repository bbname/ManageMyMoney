using System.Collections.Generic;
using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IReadBankAccount
    {
        IEnumerable<Account> GetAllBankAccounts();
        Account GetAccountById(int id);
    }
}