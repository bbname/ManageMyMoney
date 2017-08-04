using System;
using System.Collections.Generic;
using MMM.Model;
using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class ReadTransaction : IReadTransaction
    {
        private readonly ITransactionReadRepository _transactionReadRepository;
        public ReadTransaction(ITransactionReadRepository transactionReadRepository)
        {
            this._transactionReadRepository = transactionReadRepository;
        }
        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactionReadRepository.GetAllData();
        }

        public Transaction GetTransactionById(int id)
        {
            return _transactionReadRepository.GetById(id);
        }

        public IEnumerable<Transaction> GetTransactionsByFilters(int bankAccount, DateTime? fromDate, DateTime? toDate, int? itemsForPage, string filterName, string filterValue)
        {
            return _transactionReadRepository.GetTransactionsByFilters(bankAccount, fromDate, toDate, itemsForPage, filterName,
                filterValue);
        }
    }
}