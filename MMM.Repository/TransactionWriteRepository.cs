using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using MMM.Model;
using MMM.Repository.Interfaces;

namespace MMM.Repository
{
    public class TransactionWriteRepository : WriteRepository<Transaction>, ITransactionWriteRepository
    {
        public TransactionWriteRepository(DbContext ctx) : base(ctx)
        {
            
        }

        public override void Edit(Transaction entity)
        {
            _dbSet.AddOrUpdate(entity);
        }
    }
}
