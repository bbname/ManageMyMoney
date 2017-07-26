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
    }
}