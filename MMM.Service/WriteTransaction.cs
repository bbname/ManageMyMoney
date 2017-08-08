using MMM.Model;
using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class WriteTransaction : IWriteTransaction
    {
        private readonly ITransactionWriteRepository _transactionWriteRepository;
        public WriteTransaction(ITransactionWriteRepository transactionWriteRepository)
        {
            this._transactionWriteRepository = transactionWriteRepository;
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

        public void DeleteById(int id)
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