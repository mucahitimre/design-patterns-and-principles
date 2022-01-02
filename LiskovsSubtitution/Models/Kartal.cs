using LiskovsSubtitution.Abstractions;

namespace LiskovsSubtitution.Models;

public class Kartal : Car
{
    public static Kartal CreateByName(string name)
    {
        return new Kartal() { Name = name };
    }

    public override string Name { get; protected set; }

    public override void Run()
    {
        Console.WriteLine($"{GetType().Name} is runuing..");
    }
}