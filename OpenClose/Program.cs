using Microsoft.Extensions.DependencyInjection;

namespace OpenClose;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        var ioC = serviceCollection
            .AddTransient<IPaymentManager, PaymentManager>()
            .AddTransient<IPaymentType, CreditCartPaymentType>()
            .AddTransient<IPaymentType, TransferPaymentType>()
            .AddTransient<IPaymentType, PayAtDoorPaymentType>()
            .BuildServiceProvider();

        /*
         * Ödeme tipi if case'i ile değilde dışarıdan gelen model ile belirleniyor, 
            ayrıca yeni bir ödeme iti eklendiğinde sadece interface'den türetmek ve context'den onun select edilmesi gerekiyor,
            bu şelikde genişlemeye-gelişmeye açık değişime kapalı bir yapı inşa etmiş oluyoruz.
         */

        var manager = ioC.GetService<IPaymentManager>();
        var paymentType = manager.GetCurrentPaymentType(new DefaultCartContext());
        var response = paymentType.Pay(new DefaultCartContext());
        if (response.IsSuccess)
        {
            Console.WriteLine("Payment received successfully..");
        }
        else
        {
            Console.WriteLine($"An error occurred while receiving the payment.: {response.Message}");
        }

        Console.WriteLine("Hello World!");
    }
}