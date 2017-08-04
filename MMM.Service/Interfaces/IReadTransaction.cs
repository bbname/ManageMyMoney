using System;
using System.Collections.Generic;
using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IReadTransaction
    {
        IEnumerable<Transaction> GetTransactionsByFilters(int bankAccount, DateTime? fromDate, DateTime? toDate, int? itemsForPage, string filterName, string filterValue);
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int id);
    }
}