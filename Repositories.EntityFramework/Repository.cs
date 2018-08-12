using Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repositories.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        public Repository(DbContext content)
        {
            this._context = content;
        }

        public virtual void Add(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
        }

        public virtual TEntity Create()
        {
            return new TEntity();
        }

        public virtual TEntity Get(string id)
        {
            return this._context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this._context.Set<TEntity>().Select(e => e);
        }

        public virtual void Remove(TEntity entity)
        {
            this._context.Set<TEntity>().Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
