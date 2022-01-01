using Microsoft.Extensions.DependencyInjection;

namespace SingleResposibility;

public class Program
{
    public static void Main(string[] args)
    {
        // Setup our DI
        ServiceProvider Service = BuildServices();

        var member = new Member();
        var requestModel = new SearchModel()
        {
            NumberOfPersons = 5,
            CityName = "Antalya",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(5)
        };

        var finder = Service.GetService<IReservationFinder>();
        var hotels = finder.Search(requestModel);
        if (hotels != null && hotels.Any())
        {
            var selectedOtel = hotels.First();
            // select hotel: hotels.First()
            var reservation = new DefaultReservation()
            {
                HotelId = selectedOtel.Id,
                NumberOfPersons = requestModel.NumberOfPersons,
                StartDate = requestModel.StartDate,
                EndDate = requestModel.EndDate,
            };

            var builder = Service.GetService<IReservationDao>();
            builder.Insert(member, reservation);
            if (reservation.Id != default)
            {
                var printer = Service.GetService<IReservationPrinter>();
                var printerUrl = printer.GetDownloadUrl(PdfPrintProvider.KEY, reservation);

                var emailSender = Service.GetService<IEmailSender>();
                emailSender.SendAsyncEmail(member, reservation);

                Console.WriteLine($"Download url {printerUrl.Result}");
                Console.ReadKey();
                // redirect download url..
            }

            throw new Exception($"{selectedOtel.Name} hotel reservation could not be made..");
        }

        Console.WriteLine("Hello, World!");
        Console.ReadKey();
    }

    private static ServiceProvider BuildServices()
    {
        var vendors = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(e => e.IsAssignableTo(typeof(IVendor)) && e != typeof(IVendor));
        var providers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(e => e.IsAssignableTo(typeof(IPrinterDataProvider)) && e != typeof(IPrinterDataProvider));
        var serviceProvider = new ServiceCollection();

        foreach (var item in vendors)
        {
            serviceProvider.AddScoped(typeof(IVendor), item);
        }

        foreach (var item in providers)
        {
            serviceProvider.AddScoped(typeof(IPrinterDataProvider), item);
        }

        var host = serviceProvider
            .AddScoped(typeof(IReservationDao), typeof(ReservationDao))
            .AddScoped(typeof(IReservationPrinter), typeof(ReservationPrinter))
            .AddScoped(typeof(IReservationFinder), typeof(ReservationFinder))
            .AddScoped(typeof(IEmailSender), typeof(EmailSender))
            .AddScoped(typeof(IPrinter), typeof(FilePrinter))
            .BuildServiceProvider();

        return host;
    }
}
