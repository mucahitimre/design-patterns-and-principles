namespace UnitOfWork
{
    public interface IUnitOfWorkSession : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntity, new();

        void Commit();
    }
}
