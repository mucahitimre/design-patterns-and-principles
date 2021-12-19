using System.Linq.Expressions;

namespace UnitOfWork
{
    public class LocalRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        public List<Action> Actions { get; set; } = new();

        public List<TEntity> Entities { get; set; } = new List<TEntity>();

        public LocalRepository()
        {
        }

        public void Delete(TEntity entity)
        {
            Actions.Add(() =>
            {
                if (!Entities.Remove(entity))
                {
                    // logger 
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
            Actions.Add(() => Entities.Add(entity));
        }

        public void Update(TEntity entity)
        {
            Actions.Add(() =>
            {
                var updated = Get(entity.Id);
                if (updated != null)
                {
                    var index = Entities.IndexOf(updated);
                    Entities[index] = entity;
                }
            });
        }
    }
}
