﻿using System;
using System.Collections.Generic;
using System.Linq;
using MMM.Model;
using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class WriteTransaction : IWriteTransaction
    {
        private readonly ITransactionWriteRepository _transactionWriteRepository;
        private readonly ITransactionReadRepository _transactionReadRepository;
        public WriteTransaction(ITransactionWriteRepository transactionWriteRepository, ITransactionReadRepository transactionReadRepository)
        {
            this._transactionWriteRepository = transactionWriteRepository;
            this._transactionReadRepository = transactionReadRepository;
        }

        public void UpdateTransactionsBalanceForNewer(DateTime setDateChangedTransaction, string bankAccountId, decimal differenceAmount, string editedTranasctionId)
        {
            var listTransactions = _transactionReadRepository.GetAllData(bankAccountId);
            listTransactions = listTransactions.Where(t => t.SetDate >= setDateChangedTransaction);

            if (!String.IsNullOrEmpty(editedTranasctionId))
            {
                //var editedTransaction = _transactionReadRepository.GetById(editedTranasctionId.Value);
                listTransactions = listTransactions.Where(t => t.Id != editedTranasctionId);
                //var status = listTransactions.ToList().Remove(editedTransaction);
            }

            foreach (var transaction in listTransactions)
            {
                transaction.AccountBalance -= differenceAmount;
                _transactionWriteRepository.Edit(transaction);
            }

            _transactionWriteRepository.Save();

        }
        public void Create(Transaction transaction)
        {
            _transactionWriteRepository.Add(transaction);
            _transactionWriteRepository.Save();
        }

        public void Edit(Transaction transaction)
        {
            _transactionWriteRepository.Edit(transaction);
            _transactionWriteRepository.Save();
        }

        public void DeleteById(string id)
        {
            _transactionWriteRepository.DeleteById(id);
            _transactionWriteRepository.Save();
        }

        public void Delete(Transaction transaction)
        {
            _transactionWriteRepository.Delete(transaction);
            //_transactionWriteRepository.Save();
        }
    }
}