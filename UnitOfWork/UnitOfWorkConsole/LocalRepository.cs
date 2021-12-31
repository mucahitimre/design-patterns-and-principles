using System.Linq.Expressions;
using UnitOfWorkConsole.Abstractions;

namespace UnitOfWorkConsole
{
    public class LocalRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private bool _disposedValue;
        private readonly IContextHandler _contextHandler;

        private List<TEntity> Entities { get; set; } = new List<TEntity>();

        public LocalRepository(IContextHandler contextHandler)
        {
            _contextHandler = contextHandler;
        }

        public void Delete(TEntity entity)
        {
            _contextHandler.Context.Add(new ContextModel
            {
                Entity = entity,
                Action = () =>
                {
                    if (!Entities.Remove(entity))
                    {
                        // logger 
                    }
                }
            });
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            var data = Entities.Where(expression.Compile());

            return data.ToList();
        }

        public TEntity Get(Guid id)
        {
            return Entities.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities;
        }

        public void Insert(TEntity entity)
        {
            _contextHandler.Context.Add(new ContextModel
            {
                Entity = entity,
                Action = () => Entities.Add(entity)
            });
        }

        public void Update(TEntity entity)
        {
            _contextHandler.Context.Add(new ContextModel
            {
                Entity = entity,
                Action = () =>
                {
                    var updated = Get(entity.Id);
                    if (updated != null)
                    {
                        var index = Entities.IndexOf(updated);
                        Entities[index] = entity;
                    }
                }
            });
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    GC.SuppressFinalize(Entities);
                    GC.SuppressFinalize(_contextHandler);
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
