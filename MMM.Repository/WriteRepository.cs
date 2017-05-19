using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using MMM.Repository.Interfaces;

namespace MMM.Repository
{
    public abstract class WriteRepository<TEntity> : Repository<TEntity>,IWriteRepository<TEntity> where TEntity : class
    {

        public WriteRepository(DbContext ctx) : base(ctx)
        {
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var objToDelete = _dbSet.Find(id);
            _dbSet.Remove(objToDelete);
        }

        public virtual void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
