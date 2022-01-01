namespace DependencyInversion.Abstractions;

public interface INotificationProvider
{
    Type Type { get; }

    void Send(ISendModel model);
}
