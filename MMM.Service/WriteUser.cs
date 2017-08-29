using MMM.Repository.Interfaces;
using MMM.Service.Interfaces;

namespace MMM.Service
{
    public class WriteUser : IWriteUser
    {
        private readonly IUserWriteRepository _userWriteRepository;

        public WriteUser(IUserWriteRepository userWriteRepository)
        {
            this._userWriteRepository = userWriteRepository;
        }


    }
}