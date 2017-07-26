using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IReadUser
    {
        User GetUserById(string id);
    }
}