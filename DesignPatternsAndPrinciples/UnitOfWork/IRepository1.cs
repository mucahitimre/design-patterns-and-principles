namespace UnitOfWork
{
    public interface IRepository
    {
        List<Action> Actions { get; set; }
    }
}
