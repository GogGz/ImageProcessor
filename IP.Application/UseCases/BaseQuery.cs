using IP.Application.Interfaces.Persistence;

namespace IP.Application.UseCases
{
    public class BaseQuery<TEntity> where TEntity : class
    {
        public BaseQuery(IRepository<TEntity> repository)
        {
            Repository = repository;
        }
        public IRepository<TEntity> Repository { get; set; }
    }
}
