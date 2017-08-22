using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public Transaction GetTransactionById(string id)
        {
            return _transactionReadRepository.GetById(id);
        }

        public Transaction GetTransactionById(string transactionId, string bankAccountId)
        {
            return _transactionReadRepository.GetTransactionById(transactionId, bankAccountId);
        }

        public IEnumerable<Transaction> GetSearchTransactionsByFilters(string bankAccountId, DateTime? fromDate, DateTime? toDate, string filterName, string filterValue, string searchText)
        {
            return _transactionReadRepository.GetTransactionsByFilters(bankAccountId, fromDate, toDate, filterName, filterValue).Where(t => t.Name.Contains(searchText));
        }

        public IEnumerable<Transaction> GetTransactionsByFilters(string bankAccountId, DateTime? fromDate, DateTime? toDate, string filterName, string filterValue)
        {
            return _transactionReadRepository.GetTransactionsByFilters(bankAccountId, fromDate, toDate, filterName, filterValue);
        }

        public bool IsTransactionCorrect(string transactionId, string bankAccountId, string userId)
        {
            return _transactionReadRepository.IsTransactionCorrect(transactionId, bankAccountId, userId);
        }

        public IEnumerable<string> GetTransactionNamesBySimilarName(string bankAccountId, string name)
        {
            var transactions = _transactionReadRepository.GetAllData(bankAccountId)
                .Where(t => t.Name.ToLower().StartsWith(name.ToLower()))
                .Take(10)
                .Select(t => t.Name);

            return transactions;
        }


        public IEnumerable<Transaction> GetTransactionByName(string name, string bankAccountId)
        {
            return _transactionReadRepository.GetAllData(bankAccountId).Where(t => t.Name == name).Take(1);
        }
    }
}