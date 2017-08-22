﻿using System;
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

        public Transaction GetTransactionById(int id)
        {
            return _transactionReadRepository.GetById(id);
        }

        public Transaction GetTransactionById(int id, int bankAccountId)
        {
            return _transactionReadRepository.GetTransactionById(id, bankAccountId);
        }

        public IEnumerable<Transaction> GetSearchTransactionsByFilters(int bankAccount, DateTime? fromDate, DateTime? toDate, string filterName, string filterValue, string searchText)
        {
            return _transactionReadRepository.GetTransactionsByFilters(bankAccount, fromDate, toDate, filterName, filterValue).Where(t => t.Name.Contains(searchText));
        }

        public IEnumerable<Transaction> GetTransactionsByFilters(int bankAccount, DateTime? fromDate, DateTime? toDate, string filterName, string filterValue)
        {
            return _transactionReadRepository.GetTransactionsByFilters(bankAccount, fromDate, toDate, filterName, filterValue);
        }

        public bool IsTransactionCorrect(int id, int bankAccountId, string userId)
        {
            return _transactionReadRepository.IsTransactionCorrect(id, bankAccountId, userId);
        }

        public IEnumerable<string> GetTransactionNamesBySimilarName(int bankAccountId, string name)
        {
            var transactions = _transactionReadRepository.GetAllData(bankAccountId)
                .Where(t => t.Name.ToLower().StartsWith(name.ToLower()))
                .Take(10)
                .Select(t => t.Name);

            return transactions;
        }


        public IEnumerable<Transaction> GetTransactionByName(string name, int bankAccountId)
        {
            return _transactionReadRepository.GetAllData(bankAccountId).Where(t => t.Name == name).Take(1);
        }
    }
}