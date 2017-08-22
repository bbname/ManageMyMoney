using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMM.Model;

namespace MMM.Repository.Interfaces
{
    public interface ITransactionReadRepository : IReadRepository<Transaction>
    {
        IEnumerable<Transaction> GetTransactionsByFilters(string bankAccountId, DateTime? fromDate, DateTime? toDate, string filterName, string filterValue);

        bool IsTransactionCorrect(string transactionId, string bankAccountId, string userId);

        IEnumerable<Transaction> GetAllData(string bankAccountId);

        Transaction GetTransactionById(string transactionId, string bankAccountId);
    }
}
