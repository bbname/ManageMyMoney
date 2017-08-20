using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MMM.Model;
using MMM.Repository.Interfaces;

namespace MMM.Repository
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(DbContext ctx) : base  (ctx)
        {
            
        }

        public void AddUserToRole(string userId)
        {
            var userStore = new UserStore<User>(_ctx);
            var userManager = new UserManager<User>(userStore);

            userManager.AddToRole(userId, "User");
        }
    }
}