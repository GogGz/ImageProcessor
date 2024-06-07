using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IP.Application.Interfaces.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        void Save();
        Task SaveAsync();
        void Update(TEntity entityToUpdate);
    }
}