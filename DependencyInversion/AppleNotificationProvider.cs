﻿namespace DependencyInversionConsole;

public class AppleNotificationProvider : INotificationProvider
{
    public Type Type => GetType();

    public void Send(ISendModel model)
    {
        //send android notification
    }
}