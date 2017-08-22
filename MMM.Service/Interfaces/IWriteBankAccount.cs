using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IWriteBankAccount
    {
        void Create(BankAccount bankAccount);
        void Edit(BankAccount bankAccount);
        void Delete(string id);
    }
}