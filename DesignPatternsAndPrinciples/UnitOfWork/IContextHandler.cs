namespace UnitOfWork
{
    public interface IContextHandler : IDisposable
    {
        IUowContext Context { get; }

        void ClearContext();
    }
}
