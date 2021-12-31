using Microsoft.Extensions.DependencyInjection;

namespace DependencyInversionConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddTransient<INotificationService, NotificationService>();
        services.AddTransient<INotificationProvider, AndroidNotificationProvider>();
        services.AddTransient<INotificationProvider, AppleNotificationProvider>();
        var ioc = services.BuildServiceProvider();

        var notificationService = ioc.GetService<INotificationService>();
        notificationService.SendNotification(new DefaultSendModel
        {
            Message = "Alişverişiniz yola çıktı.."
        }, e => e.Type.Name != typeof(AndroidNotificationProvider).Name);

        Console.WriteLine("Hello World!");
    }
}