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


            // First version of adding data by seed. Admin account.
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

            // Second version of adding data by seed. Test user account.
            if (!(context.Users.Any(u => u.UserName == "test")))
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var userToCreate = new User
                {
                    UserName = "test",
                    Email = "bbai.web@gmail.com",
                    FirstName = "Simply Test",
                    LastName = "User Account",
                };
                userManager.Create(userToCreate, "test123.");
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
