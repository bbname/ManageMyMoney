using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMM.Repository.Interfaces
{
    public interface IWriteRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void DeleteById(string id);
        void Delete(TEntity entity);
        void Save();
    }
}
