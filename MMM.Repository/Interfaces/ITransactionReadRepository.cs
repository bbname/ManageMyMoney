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
        IEnumerable<Transaction> GetTransactionsByFilters(int bankAccount, DateTime? fromDate, DateTime? toDate, string filterName, string filterValue);

        bool IsTransactionCorrect(int id, int bankAccountId, string userId);

        IEnumerable<Transaction> GetAllData(int bankAccountId);

        Transaction GetTransactionById(int id, int bankAccountId);
    }
}
