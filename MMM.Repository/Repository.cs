using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMM.Repository.Interfaces;

namespace MMM.Repository
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        protected DbContext _ctx;
        protected readonly IDbSet<TEntity> _dbSet;

        protected Repository(DbContext ctx)
        {
            this._ctx = ctx;
            _dbSet = _ctx.Set<TEntity>();
        }

    }
}
