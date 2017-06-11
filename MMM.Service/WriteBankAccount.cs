using MMM.Model;
using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class WriteBankAccount : IWriteBankAccount
    {
        private IAccountWriteRepository _accountWriteRepository;
        public WriteBankAccount(IAccountWriteRepository accountWriteRepository)
        {
            this._accountWriteRepository = accountWriteRepository;
        }
        public void Create(Account account)
        {
            _accountWriteRepository.Add(account);
            _accountWriteRepository.Save();
        }

        public void Edit(Account account)
        {
            _accountWriteRepository.Edit(account);
            _accountWriteRepository.Save();
        }

        public void Delete(int id)
        {
            _accountWriteRepository.Delete(id);
            _accountWriteRepository.Save();
        }
    }
}