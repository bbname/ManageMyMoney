using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Web.WebPages;
using MMM.Model;
using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class ReadBankAccount : IReadBankAccount
    {
        private readonly IBankAccountReadRepository _bankAccountReadRepository;
        public ReadBankAccount(IBankAccountReadRepository bankAccountReadRepository)
        {
            this._bankAccountReadRepository = bankAccountReadRepository;
        }
        public IEnumerable<BankAccount> GetAllBankAccountsByUserId(string userId)
        {
            return this._bankAccountReadRepository.GetBankAccountsByUserId(userId);
        }

        public BankAccount GetAccountById(int id)
        {
            return this._bankAccountReadRepository.GetById(id);
        }

        public string GetUserIdByBankAccountId(int bankAccountId)
        {
            try
            {
                return this._bankAccountReadRepository.GetUserIdByBankAccountId(bankAccountId);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Nie masz takiego konta bankowego.");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public bool IsBankAccountCorrect(int id, string userId)
        {
            return this._bankAccountReadRepository.IsBankAccountCorrect(id, userId);
        }
    }
}