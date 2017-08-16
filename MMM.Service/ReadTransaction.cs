﻿using System;
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

        public IEnumerable<Transaction> GetTransactionsByFilters(int bankAccount, DateTime? fromDate, DateTime? toDate, string filterName, string filterValue)
        {
            return _transactionReadRepository.GetTransactionsByFilters(bankAccount, fromDate, toDate, filterName, filterValue);
        }

        public bool IsTransactionCorrect(int id, int bankAccountId, string userId)
        {
            return _transactionReadRepository.IsTransactionCorrect(id, bankAccountId, userId);
        }
    }
}