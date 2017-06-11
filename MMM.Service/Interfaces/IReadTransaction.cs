using System.Collections.Generic;
using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IReadTransaction
    {
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int id);
    }
}