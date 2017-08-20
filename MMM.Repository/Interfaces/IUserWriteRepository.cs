using MMM.Model;

namespace MMM.Repository.Interfaces
{
    public interface IUserWriteRepository : IWriteRepository<User>
    {
        void AddUserToRole(string userId);
    }
}