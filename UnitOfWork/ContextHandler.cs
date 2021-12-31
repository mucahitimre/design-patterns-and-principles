using UnitOfWorkConsole.Abstractions;

namespace UnitOfWorkConsole
{
    public class ContextHandler : IContextHandler
    {
        private bool _disposedValue;
        private IUowContext _contextModels;
        private static readonly object _lock = new();

        private void BuildContext()
        {
            if (_contextModels == null)
            {
                lock (_lock)
                {
                    if (_contextModels == null)
                    {
                        _contextModels = new UowContext();
                    }
                }
            }
        }

        public void ClearContext()
        {
            _contextModels = null;
        }

        public IUowContext Context { get { BuildContext(); return _contextModels; } }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _contextModels = null;
                    // TODO: dispose managed state (managed objects)
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
