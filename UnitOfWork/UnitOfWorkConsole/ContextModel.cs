using UnitOfWorkConsole.Abstractions;

namespace UnitOfWorkConsole
{
    public class ContextModel : IContextModel
    {
        public Action Action { get; set; }

        public IEntity Entity { get; set; }
    }
}
