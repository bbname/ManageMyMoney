using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMM.Model;
using MMM.Repository.Interfaces;

namespace MMM.Repository
{
    public class BankAccountWriteRepository : WriteRepository<BankAccount>, IBankAccountWriteRepository
    {
        public BankAccountWriteRepository(DbContext ctx) : base(ctx)
        {

        }
    }
}
