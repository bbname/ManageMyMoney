using MMM.Model;
using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class WriteBankAccount : IWriteBankAccount
    {
        private readonly IAccountWriteRepository _accountWriteRepository;
        public WriteBankAccount(IAccountWriteRepository accountWriteRepository)
        {
            this._accountWriteRepository = accountWriteRepository;
        }
        public void Create(BankAccount bankAccount)
        {
            _accountWriteRepository.Add(bankAccount);
            _accountWriteRepository.Save();
        }

        public void Edit(BankAccount bankAccount)
        {
            _accountWriteRepository.Edit(bankAccount);
            _accountWriteRepository.Save();
        }

        public void Delete(int id)
        {
            _accountWriteRepository.DeleteById(id);
            _accountWriteRepository.Save();
        }
    }
}