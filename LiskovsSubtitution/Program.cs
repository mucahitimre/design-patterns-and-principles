using LiskovsSubtitution.Abstractions;
using LiskovsSubtitution.Models;

namespace LiskovsSubtitution;

public class Program
{
    private static void Main(string[] args)
    {
        /*
         * Burada Car'dan türetilmiş her class'ın Car'ın taşıdığı özellikleri karşılayabilmesi gerekmektedir,
            ve klimasız arabalarda olabileceğinden klima açma özelliğini Car'dan ayırarak 
            Car'dan türeyen class'ların tüm özelliklerini gerçekleştirebimesini sağlamış olduk,
            bu da bize Car'ın tüm özellikleri onu base alan class'lar tarafından gerçekleştirileceğini garanti etmiş oldu,
            klima özelliğini'de ayrı bir interface ile yöneterek entegre etmiş olduk.
         */

        var ferrari = new Ferrari();
        ferrari.Run();
        if (ferrari is IAirConditionable airConditionableFerrari)
        {
            airConditionableFerrari.OpenAirConditioning();
        }

        var kartal = new Kartal();
        kartal.Run();
        if (kartal is IAirConditionable airConditionableKartal)
        {
            airConditionableKartal.OpenAirConditioning();
        }

        Console.WriteLine("Hello World!");
        Console.ReadLine();
    }
}