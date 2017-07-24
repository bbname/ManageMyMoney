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
                    context.SaveChanges();
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
                context.SaveChanges();
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
                context.SaveChanges();
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

            // Transactions for specified bank accounts of users.
            // Admin
            ICollection<Transaction> listAdminTransactions = new List<Transaction>
            {
                new Transaction{Name = "Sklep - zakupy", AccountBalance = 99.99M, Amount = 15.69M, Created = DateTime.Now.AddDays(1)},
                new Transaction{Name = "Koszulki", AccountBalance = 84.3M, Amount = 39.98M, Created = DateTime.Now.AddDays(2)},
                new Transaction{Name = "Pizza", AccountBalance = 44.32M, Amount = 20.99M, Created = DateTime.Now.AddDays(3)},
            };

            if (!(context.Transactions.Any(x => x.Amount == listAdminTransactions.FirstOrDefault(t => t.AccountBalance == 99.99M).Amount)))
            {
                context.Transactions.AddRange(listAdminTransactions);
                context.SaveChanges();
            }

            // Test
            ICollection<Transaction> listTestTransactions = new List<Transaction>
            {
                new Transaction{Name = "Opony do audi", AccountBalance = 1459.63M, Amount = 459.03M, Created = DateTime.Now.AddDays(5)},
                new Transaction{Name = "Nowy wydech do audi", AccountBalance = 1000.6M, Amount = 100.6M, Created = DateTime.Now.AddDays(2)},
                new Transaction{Name = "Wesele Zdzis³awa", AccountBalance = 900M, Amount = 600M, Created = DateTime.Now.AddDays(9)},
            };

            if (!(context.Transactions.Any(x => x.Amount == listTestTransactions.FirstOrDefault(t => t.AccountBalance == 99.99M).Amount)))
            {
                context.Transactions.AddRange(listTestTransactions);
                context.SaveChanges();
            }

            // Bank accounts for users.
            // Admin
            if (!(context.Accounts.Any(b => b.User.Id == userAdminId)))
            {
                var bankAccount = new Account
                {
                    Name = "Studenckie",
                    Balance = 99.99M,
                    Currency = 1,
                    Created = DateTime.Now,
                    User = (User)context.Users.First(u => u.Id == userAdminId),
                    Transactions = listAdminTransactions
                };
                context.Accounts.AddOrUpdate(bankAccount);
                context.SaveChanges();
            }

            // Test
            if (!(context.Accounts.Any(b => b.User.Id == userTestId)))
            {
                var bankAccount = new Account
                {
                    Name = "Standard",
                    Balance = 1459.63M,
                    Currency = 3,
                    Created = DateTime.Now,
                    User = (User)context.Users.First(u => u.Id == userTestId),
                    Transactions = listTestTransactions
                };
                context.Accounts.AddOrUpdate(bankAccount);
                context.SaveChanges();
            }
        }
    }
}
