using LiskovsSubtitution.Abstractions;

namespace LiskovsSubtitution.Models;

public class Kartal : Car
{
    public override void Run()
    {
        Console.WriteLine($"{GetType().Name} is runuing..");
    }
}