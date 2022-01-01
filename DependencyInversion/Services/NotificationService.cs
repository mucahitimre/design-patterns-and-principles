using DependencyInversion.Abstractions;

namespace DependencyInversion.Services;

public class NotificationService : INotificationService
{
    private readonly IEnumerable<INotificationProvider> _providers;

    public NotificationService(IEnumerable<INotificationProvider> providers)
    {
        _providers = providers;
    }

    public void SendNotification(ISendModel model, Func<INotificationProvider, bool> func)
    {
        /* 
         * Burada INotificationProvider'dan implement edilmiş classları tek tek çağırarak kullanmak yerine
                araya bir soyutlama katmanı(INotificationProvider) ekleyerek NotificationService üst katmanını 
                alt katman(lar) olan NotificationProvider'lardan ayırmış ve bağımlılığı INotificationProvider'ın 
                implement edileceği class'a aktarmış olduk.

         * Yeni bir NotificationProvider eklendiğinde burada bir kod değiştirmek zorunda olmayacağız.
         */

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
                throw e;
            }
        }
    }
}
