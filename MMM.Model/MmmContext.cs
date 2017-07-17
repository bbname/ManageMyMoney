using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

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
            base.OnModelCreating(modelBuilder);
        }

        public static MmmContext Create()
        {
            return new MmmContext();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //public System.Data.Entity.DbSet<MMM.ViewModels.BankAccountViewModel.BankAccountListViewModel> BankAccountListViewModels { get; set; }
    }
}