using MMM.Model;
using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class ReadUser : IReadUser
    {
        private readonly IUserReadRepository _userReadRepository;

        public ReadUser(IUserReadRepository userReadRepository)
        {
            this._userReadRepository = userReadRepository;
        }
        public User GetUserById(string id)
        {
            return this._userReadRepository.GetUserById(id);
        }
    }
}