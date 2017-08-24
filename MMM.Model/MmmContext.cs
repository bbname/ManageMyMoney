using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using MMM.Model.Configurations;

namespace MMM.Model
{
    public class MmmContext : IdentityDbContext
    {
        public MmmContext()
            //: base("DefaultConnection") For local database to see in server explorer in visual studio.
            : base("SQLServerConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new BankAccountConfiguration());
            modelBuilder.Configurations.Add(new TransactionConfiguration());

            modelBuilder.Entity<BankAccount>()
                .HasRequired(b => b.User);
            modelBuilder.Entity<BankAccount>()
                .HasMany(b => b.Transactions);

            modelBuilder.Entity<Transaction>()
                .HasRequired(t => t.BankAccount);

            base.OnModelCreating(modelBuilder);
        }

        public static MmmContext Create()
        {
            return new MmmContext();
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}