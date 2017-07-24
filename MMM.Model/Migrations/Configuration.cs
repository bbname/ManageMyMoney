using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MMM.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MMM.Model.MmmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MMM.Model.MmmContext context)
        {
            IEnumerable<string> roleList = new List<string>()
            {
                "Admin",
                "User",
                "Guest"
            };

            // Roles creation.

            foreach (var role in roleList)
            {
                if (!(context.Roles.Any(r => r.Name == role)))
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    var roleToCreate = new IdentityRole() {Name = role};
                    roleManager.Create(roleToCreate);
                }
            }

            // First version of creation user. Admin account.
            if (!(context.Users.Any(u => u.UserName == "admin")))
            {
                var passwordHash = new PasswordHasher();
                string password = passwordHash.HashPassword("admin123.");
                context.Users.AddOrUpdate(u => u.UserName, new User()
                {
                    UserName = "admin",
                    Email = "bbai.web@gmail.com",
                    FirstName = "Bart³omiej",
                    LastName = "Bieñczyk",
                    PasswordHash = password
                });
            }

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            // Second version of creation user. Test user account.
            if (!(context.Users.Any(u => u.UserName == "test")))
            {
                var userToCreate = new User
                {
                    UserName = "test",
                    Email = "bbai.web@gmail.com",
                    FirstName = "Simply Test",
                    LastName = "User Account",
                };
                userManager.Create(userToCreate, "test123.");
            }

            // Users and roles pair.
            var userAdminId = context.Users.FirstOrDefault(u => u.UserName == "admin").Id;
            var userTestId = context.Users.FirstOrDefault(u => u.UserName == "test").Id;

            if (!(userManager.IsInRole(userAdminId, "Admin")))
            {
                userManager.AddToRole(userAdminId, "Admin");
            }
            if (!(userManager.IsInRole(userTestId, "User")))
            {
                userManager.AddToRole(userTestId, "User");
            }
        }
    }
}
