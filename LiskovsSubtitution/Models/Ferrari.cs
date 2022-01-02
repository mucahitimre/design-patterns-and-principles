using LiskovsSubtitution.Abstractions;

namespace LiskovsSubtitution.Models;

public class Ferrari : Car, IAirConditionable
{
    public static Ferrari CreateByName(string name)
    {
        return new Ferrari() { Name = name };
    }

    public override string Name { get; protected set; }

    public void OpenAirConditioning()
    {
        Console.WriteLine($"{GetType().Name} air conditioner on..");
    }

    public override void Run()
    {
        Console.WriteLine($"{GetType().Name} is runuing..");
    }
}