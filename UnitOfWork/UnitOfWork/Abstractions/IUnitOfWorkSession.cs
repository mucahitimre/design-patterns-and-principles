namespace UnitOfWork.Abstractions;

public interface IUnitOfWorkSession : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class, IEntity, new();

    void Commit();
}
