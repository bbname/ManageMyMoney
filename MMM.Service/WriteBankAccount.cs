using MMM.Model;
using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class WriteBankAccount : IWriteBankAccount
    {
        private readonly IBankAccountWriteRepository _bankAccountWriteRepository;
        public WriteBankAccount(IBankAccountWriteRepository bankAccountWriteRepository)
        {
            this._bankAccountWriteRepository = bankAccountWriteRepository;
        }
        public void Create(BankAccount bankAccount)
        {
            _bankAccountWriteRepository.Add(bankAccount);
            _bankAccountWriteRepository.Save();
        }

        public void Edit(BankAccount bankAccount)
        {
            _bankAccountWriteRepository.Edit(bankAccount);
            _bankAccountWriteRepository.Save();
        }

        public void Delete(string id)
        {
            _bankAccountWriteRepository.DeleteById(id);
            _bankAccountWriteRepository.Save();
        }
    }
}