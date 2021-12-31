namespace DependencyInversionConsole;

public class NotificationService : INotificationService
{
    private readonly IEnumerable<INotificationProvider> _providers;

    public NotificationService(IEnumerable<INotificationProvider> providers)
    {
        _providers = providers;
    }

    public void SendNotification(ISendModel model, Func<INotificationProvider, bool> func)
    {
        foreach (var provider in _providers)
        {
            if (func != null && !func.Invoke(provider))
            {
                continue;
            }

            try
            {
                provider.Send(model);
            }
            catch (Exception e)
            {
                // log..
                throw;
            }
        }
    }
}
