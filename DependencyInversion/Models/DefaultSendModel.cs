using DependencyInversion.Abstractions;

namespace DependencyInversion.Models;

public class DefaultSendModel : ISendModel
{
    public string Message { get; set; }
}