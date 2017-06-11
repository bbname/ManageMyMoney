using System.Collections.Generic;
using MMM.Model;
using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class ReadBankAccount : IReadBankAccount
    {
        private IAccountReadRepository _accountReadRepository;
        public ReadBankAccount(IAccountReadRepository accountReadRepository)
        {
            this._accountReadRepository = accountReadRepository;
        }
        public IEnumerable<Account> GetAllBankAccounts()
        {
            return this._accountReadRepository.GetAllData();
        }

        public Account GetAccountById(int id)
        {
            return this._accountReadRepository.GetById(id);
        }
    }
}