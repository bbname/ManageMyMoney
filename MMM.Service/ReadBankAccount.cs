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
        private readonly IAccountReadRepository _accountReadRepository;
        public ReadBankAccount(IAccountReadRepository accountReadRepository)
        {
            this._accountReadRepository = accountReadRepository;
        }
        public IEnumerable<Account> GetAllBankAccountsByUserId(string userId)
        {
            return this._accountReadRepository.GetBankAccountsByUserId(userId);
        }

        public Account GetAccountById(int id)
        {
            return this._accountReadRepository.GetById(id);
        }

        public string GetUserIdByBankAccountId(int bankAccountId)
        {
            try
            {
                return this._accountReadRepository.GetUserIdByBankAccountId(bankAccountId);
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
    }
}