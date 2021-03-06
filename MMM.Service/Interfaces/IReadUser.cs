﻿using MMM.Model;

namespace MMM.Service.Interfaces
{
    public interface IReadUser
    {
        User GetUserByIdForEditAction(string id);
        User GetUserById(string id);
        string GetUserIdByProviderKey(string providerKey);
        string GetUserNameById(string userId);
        bool IsUserEmailConfirmed(string userId);
        string GetUserEmailById(string userId);
        bool IsUserNameTaken(string userName);
        bool IsUserEmailTaken(string userEmail);
        bool IsUserExist(string userId);
        string GetUserIdByUserName(string userName);
    }
}