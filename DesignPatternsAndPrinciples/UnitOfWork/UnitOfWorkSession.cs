namespace UnitOfWork
{
    public class UnitOfWorkSession : IUnitOfWorkSession, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private bool _disposedValue;

        private IRepository _repository;

        public UnitOfWorkSession(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntity, new()
        {
            _repository = (IRepository<TEntity>)_serviceProvider.GetService(typeof(IRepository<TEntity>));

            return (IRepository<TEntity>)_repository;
        }

        public void Commit()
        {
            if (_disposedValue)
            {
                throw new Exception("The scope disposed.");
            }

            if (_repository != null)
            {
                // repository SaveChange
                foreach (var item in _repository.Actions)
                {
                    item();
                }

                _repository.Actions.Clear();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _repository = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWorkSession()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
