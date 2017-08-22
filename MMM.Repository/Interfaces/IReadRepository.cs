using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMM.Repository.Interfaces
{
    public interface IReadRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllData();
        TEntity GetById(string id);
    }
}
