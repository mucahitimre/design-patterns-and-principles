namespace UnitOfWork.Abstractions;

public interface IContextModel
{
    Action Action { get; set; }
    IEntity Entity { get; set; }
}
