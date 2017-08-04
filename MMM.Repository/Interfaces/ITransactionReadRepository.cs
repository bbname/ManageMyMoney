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
        IEnumerable<Transaction> GetTransactionsByFilters(int bankAccount, DateTime? fromDate, DateTime? toDate, int? itemsForPage, string filterName, string filterValue);
    }
}
