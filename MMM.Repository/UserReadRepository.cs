using System;
using System.Data.Entity;
using System.Linq;
using MMM.Model;
using MMM.Repository.Interfaces;

namespace MMM.Repository
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(DbContext ctx) : base(ctx)
        {
            
        }

        public User GetUserById(string id)
        {
            return _dbSet.Find(id);
        }

        public string GetUserIdByProviderKey(string providerKey)
        {
            //var userId = _dbSet.Select(u => u.Logins.FirstOrDefault(l => l.ProviderKey == providerKey).UserId).ToString();
            string userId = null;

            if (_dbSet.Any(u => u.Logins.Any(l => l.ProviderKey == providerKey)))
            {
                var logins = _dbSet.FirstOrDefault(u => u.Logins.Any(l => l.ProviderKey == providerKey)).Logins;

                foreach (var login in logins)
                {
                    if (login.ProviderKey == providerKey)
                    {
                        userId = login.UserId;
                        break;
                    }
                }
            }

            return userId;
        }
    }
}