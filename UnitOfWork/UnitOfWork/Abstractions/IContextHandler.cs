namespace UnitOfWork.Abstractions;

public interface IContextHandler : IDisposable
{
    IUowContext Context { get; }

    void ClearContext();
}
