namespace DependencyInversion.Abstractions;

public interface INotificationService
{
    void SendNotification(ISendModel model, Func<INotificationProvider, bool> func = null);
}
