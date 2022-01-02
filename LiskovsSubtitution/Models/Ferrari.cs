using LiskovsSubtitution.Abstractions;

namespace LiskovsSubtitution.Models;

public class Ferrari : Car, IAirConditionable
{
    public void OpenAirConditioning()
    {
        Console.WriteLine($"{GetType().Name} air conditioner on..");
    }

    public override void Run()
    {
        Console.WriteLine($"{GetType().Name} is runuing..");
    }
}