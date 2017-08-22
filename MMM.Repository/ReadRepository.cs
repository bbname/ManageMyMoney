using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MMM.Repository.Interfaces;

namespace MMM.Repository
{
    public abstract class ReadRepository<TEntity> : Repository<TEntity>,IReadRepository<TEntity> where TEntity : class
    {

        protected ReadRepository(DbContext ctx) : base(ctx)
        {

        }

        public virtual IEnumerable<TEntity> GetAllData()
        {
            return _dbSet.AsEnumerable<TEntity>();
        }

        public virtual TEntity GetById(string id)
        {
            return _dbSet.Find(id);
        }
    }
}
