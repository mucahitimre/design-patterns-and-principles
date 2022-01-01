using DependencyInversion.Abstractions;

namespace DependencyInversion.Providers;

public class AndroidNotificationProvider : INotificationProvider
{
    public Type Type => GetType();

    public void Send(ISendModel model)
    {
        System.Console.WriteLine(model.Message);
        //send android notification
    }
}
