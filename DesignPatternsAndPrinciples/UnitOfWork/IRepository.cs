using System.Linq.Expressions;

namespace UnitOfWork
{
    public interface IRepository<TEntity> : IRepository
        where TEntity : class, IEntity, new()
    {
        TEntity Get(Guid id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);
    }
}
