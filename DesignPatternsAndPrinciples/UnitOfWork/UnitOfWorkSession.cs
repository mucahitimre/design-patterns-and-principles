namespace UnitOfWork
{
    public class UnitOfWorkSession : IUnitOfWorkSession, IDisposable
    {
        private readonly IContextHandler _contextHandler;
        private readonly IServiceProvider _serviceProvider;
        private bool _disposedValue;

        public UnitOfWorkSession(
            IContextHandler contextHandler,
            IServiceProvider serviceProvider)
        {
            _contextHandler = contextHandler;
            _serviceProvider = serviceProvider;
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntity, new()
        {
            var repository = (IRepository<TEntity>)_serviceProvider.GetService(typeof(IRepository<TEntity>));

            return repository;
        }

        public void Commit()
        {
            if (_disposedValue)
            {
                throw new Exception("The scope disposed.");
            }

            var context = _contextHandler.Context;
            if (context is not null)
            {
                // repository SaveChange
                foreach (var item in context)
                {
                    var entity = item.Entity;
                    var entityType = entity.GetType();
                    Console.WriteLine($"{item.Action.Method.Name} method is runing for {entityType.Name} entity, id: {entity.Id}");

                    item.Action();

                    Console.WriteLine($"{item.Action.Method.Name} method is runned for {entityType.Name} entity, id: {entity.Id}");
                }

                _contextHandler.ClearContext();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Commit();
                    // TODO: dispose managed state (managed objects)
                    _contextHandler.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
