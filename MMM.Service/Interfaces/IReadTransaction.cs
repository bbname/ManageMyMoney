using System;
using System.Collections.Generic;
using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IReadTransaction
    {
        IEnumerable<Transaction> GetTransactionsByFilters(string bankAccountId, DateTime? fromDate, DateTime? toDate, string filterName, string filterValue);
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(string id);
        Transaction GetTransactionById(string transactionId, string bankAccountId);
        bool IsTransactionCorrect(string transactionId, string bankAccountId, string userId);
        IEnumerable<string> GetTransactionNamesBySimilarName(string bankAccountId, string name);
        IEnumerable<Transaction> GetTransactionByName(string name, string bankAccountId);
        IEnumerable<Transaction> GetSearchTransactionsByFilters(string bankAccountId, DateTime? fromDate, DateTime? toDate,
            string filterName, string filterValue, string searchText);
    }
}