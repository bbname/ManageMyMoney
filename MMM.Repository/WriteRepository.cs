using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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
            _dbSet.Attach(entity);
            _dbSet.Add(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            _dbSet.Attach(entity);
            var entry = _ctx.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public virtual void DeleteById(int id)
        {
            var objToDelete = _dbSet.Find(id);
            _dbSet.Remove(objToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
                _ctx.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                var toRefresh = ((IObjectContextAdapter)_ctx).ObjectContext;
                toRefresh.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                var toRefresh = ((IObjectContextAdapter)_ctx).ObjectContext;
                toRefresh.Refresh(RefreshMode.ClientWins, entity);
                _ctx.SaveChanges();
            }
        }

        public virtual void Save()
        {
            _ctx.SaveChanges();
        }
    }
}