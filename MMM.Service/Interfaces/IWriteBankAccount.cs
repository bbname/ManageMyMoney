using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IWriteBankAccount
    {
        void Create(Account account);
        void Edit(Account account);
        void Delete(int id);
    }
}