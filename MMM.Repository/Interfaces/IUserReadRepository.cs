﻿using MMM.Model;

namespace MMM.Repository.Interfaces
{
    public interface IUserReadRepository : IReadRepository<User>
    {
        User GetUserById(string id);
        User GetUserByIdForEditAction(string id);
        string GetUserIdByProviderKey(string providerKey);
    }
}