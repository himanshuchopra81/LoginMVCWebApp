using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    interface IApplicationUserRepository<TEntity> : IRepository<TEntity>
    {
        TEntity GetByUsername(string username);
    }
}
