using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IWriteTransaction
    {
        void Create(Transaction transaction);
        void Edit(Transaction transaction);
        void Delete(Transaction transaction);
        void DeleteById(int id);
    }
}