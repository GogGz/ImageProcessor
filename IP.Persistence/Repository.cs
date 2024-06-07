using CommonCross.ServiceRegistrations.DependencyInjection;
using IP.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor.DAL
{

    public class Repository<TEntity> : IScoped, IRepository<TEntity> where TEntity : class
    {
        private readonly ImageProcessorDbContext _context;
        private readonly DbSet<TEntity> dbSet;

        public Repository(ImageProcessorDbContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id) => dbSet.Find(id);

        public async virtual Task<TEntity> GetByIdAsync(object id) => await dbSet.FindAsync(id);

        public virtual void Insert(TEntity entity) => dbSet.Add(entity);

        public async Task InsertAsync(TEntity entity) => await dbSet.AddAsync(entity);

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
           _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
