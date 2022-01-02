namespace LiskovsSubtitution.Abstractions;

public abstract class Car
{
    public abstract string Name { get; protected set; }

    public abstract void Run();
}
