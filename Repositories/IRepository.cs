using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Get(string id);

        IEnumerable<TEntity> GetAll();

        TEntity Create();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
