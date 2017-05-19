﻿using System;
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
            : base("DefaultConnection")
        {
        }

        public static MmmContext Create()
        {
            return new MmmContext();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}