using System;
using System.Linq;
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

        public string GetUserIdByProviderKey(string providerKey)
        {
            return this._userReadRepository.GetUserIdByProviderKey(providerKey);
        }

        public string GetUserNameById(string userId)
        {
            string userName = null;

            if (this._userReadRepository.GetAllData().Any(u => u.Id == userId))
            {
                userName = this._userReadRepository.GetUserById(userId).UserName;
            }

            return userName;
        }

        public bool IsUserEmailConfirmed(string userId)
        {
            var isEmailConfirmed = false;

            if (this._userReadRepository.GetAllData().Any(u => u.Id == userId))
            {
                isEmailConfirmed = this._userReadRepository.GetUserById(userId).EmailConfirmed;
            }

            return isEmailConfirmed;
        }

        public string GetUserEmailById(string userId)
        {
            return this._userReadRepository.GetUserById(userId).Email;
        }

        public bool IsUserNameTaken(string userName)
        {
            return this._userReadRepository.GetAllData().Any(u => u.UserName == userName);
        }

        public bool IsUserEmailTaken(string userEmail)
        {
            return this._userReadRepository.GetAllData().Any(u => u.Email == userEmail);
        }

        public bool IsUserExist(string userId)
        {
            return this._userReadRepository.GetAllData().Any(u => u.Id == userId);
        }

        public string GetUserIdByUserName(string userName)
        {
            if (this._userReadRepository.GetAllData().Any(u => u.UserName == userName))
            {
                return this._userReadRepository.GetAllData().Single(u => u.UserName == userName).Id;
            }

            return null;
        }
    }
}