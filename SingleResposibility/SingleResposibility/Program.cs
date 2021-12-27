using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace SingleResposibility;

public class Program
{
    public static void Main(string[] args)
    {
        //setup our DI

        var tedarikcies = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(e => e.IsAssignableTo(typeof(ITedarikci)) && e != typeof(ITedarikci));
        var serviceProvider = new ServiceCollection();

        foreach (var item in tedarikcies)
        {
            serviceProvider.AddScoped(typeof(ITedarikci), item);
        }

        var host = serviceProvider
            .AddScoped(typeof(IRezervasyonYapici), typeof(RezervasyonYapici))
            .AddScoped(typeof(IRezervasyonCikti), typeof(RezervasyonCikti))
            .AddScoped(typeof(IOnlineRezervasyonNew), typeof(OnlineRezervasyonNew))
            .BuildServiceProvider();

        var rez = host.GetService<IOnlineRezervasyonNew>();
        var response = rez.OtelAra(new AramaModeli());
        if (response != null && response.Any())
        {
            var selectedOtel = response.First();
            // mapping.. selectedOtel => Rezervasyon
            var rezervasyon = new Rezervasyon()
            {
                KisiSayisi = 5,
                Otel = selectedOtel.Ad
            };

            var yap = host.GetService<IRezervasyonYapici>();
            var isReseversion = yap.RezervasyonYap(rezervasyon);
            if (isReseversion)
            {
                var cikti = host.GetService<IRezervasyonCikti>();
                var ciktiUrl = cikti.RezervasyonCiktiAl(CiktiType.Pdf, rezervasyon);

                // redirect download ciktiUrl..
            }

            throw new Exception($"Kardeş {selectedOtel.Ad} otel'ine reservasyon yapamadım");
        }

        Console.WriteLine("Hello, World!");
        Console.ReadKey();
    }
}

public class OnlineRezervasyon
{
    /*
     * Rezervasyon yapılması
     * Otellerin aranması
     * Çıktı alınması     
     */

    public List<Otel> OtelAra(string cityName, DateTime startDate, DateTime endDate, int count)
    {
        var result = new List<Otel>();
        result.AddRange(Tedarikci1OtelAra(cityName, startDate, endDate, count));
        result.AddRange(Tedarikci2OtelAra(cityName, startDate, endDate, count));
        result.AddRange(Tedarikci3OtelAra(cityName, startDate, endDate, count));

        var response = result.GroupBy(e => e.Id).Select(e => new Otel
        {
            Id = e.Key,
            Ad = e.First().Ad,
            Ucret = e.Min(e => e.Ucret),
            TedarikciId = e.Min(e => e.TedarikciId)
        }).ToList();

        return response;
    }

    private List<Otel> Tedarikci1OtelAra(string cityName, DateTime startDate, DateTime endDate, int count)
    {

        return new List<Otel>();
    }

    private List<Otel> Tedarikci2OtelAra(string cityName, DateTime startDate, DateTime endDate, int count)
    {

        return new List<Otel>();
    }

    private List<Otel> Tedarikci3OtelAra(string cityName, DateTime startDate, DateTime endDate, int count)
    {

        return new List<Otel>();
    }

    public bool RezervasyonYap(string cityName, DateTime startDate, DateTime endDate, int count)
    {
        return true;
    }

    public void RezervasyonlarinCiktisiniAl()
    {

    }
}

public interface IOnlineRezervasyonNew
{
    List<IOtel> OtelAra(AramaModeli model);
}

public class OnlineRezervasyonNew : IOnlineRezervasyonNew
{
    private readonly IEnumerable<ITedarikci> _tedarikcis;

    public OnlineRezervasyonNew(IEnumerable<ITedarikci> tedarikcis)
    {
        _tedarikcis = tedarikcis;
    }

    public List<IOtel> OtelAra(AramaModeli model)
    {
        var reponse = new List<IOtel>();
        var timer = new Stopwatch();
        timer.Start();
        Parallel.ForEach(_tedarikcis, async item => reponse.AddRange(await item.OtelAra(model)));
        timer.Stop();

        Console.WriteLine(timer.ElapsedMilliseconds);

        //1........ 10sn
        //2..... 5sn
        //3..1sn
        //3.................25
        var response = reponse.GroupBy(e => e.Id).Select(e => new Otel
        {
            Id = e.Key,
            Ad = e.First().Ad,
            Ucret = e.Min(e => e.Ucret),
            TedarikciId = e.Min(e => e.TedarikciId)
        }).ToList();

        return reponse;
    }
}

public interface IOtel
{
    int Id { get; set; }
    string Ad { get; set; }
    int Ucret { get; set; }
    int TedarikciId { get; set; }
}

public class Otel : IOtel
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public int Ucret { get; set; }
    public int TedarikciId { get; set; }
}

public interface ITedarikci
{
    Task<List<IOtel>> OtelAra(AramaModeli arama);
}

public class Tadarikci1 : ITedarikci
{
    public Task<List<IOtel>> OtelAra(AramaModeli arama)
    {
        // servis bağlanıp..
        Thread.Sleep(5000);

        return Task.FromResult(new List<IOtel>());
    }
}

public class Tadarikci2 : ITedarikci
{
    public Task<List<IOtel>> OtelAra(AramaModeli arama)
    {
        // excel import edebilir..
        Thread.Sleep(5000);

        return Task.FromResult(new List<IOtel>());
    }
}

public class AramaModeli
{
    public string CityName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Count { get; set; }
}

internal interface IRezervasyonYapici
{
    bool RezervasyonYap(Rezervasyon rezervasyon);
}

public class RezervasyonYapici : IRezervasyonYapici
{
    public bool RezervasyonYap(Rezervasyon rezervasyon)
    {
        return true;
    }
}

internal interface IRezervasyonCikti
{
    string RezervasyonCiktiAl(CiktiType ciktiType, Rezervasyon rezervasyon);
}

public class RezervasyonCikti : IRezervasyonCikti
{
    public string RezervasyonCiktiAl(CiktiType ciktiType, Rezervasyon rezervasyon)
    {
        return string.Empty;
    }
}

public enum CiktiType
{
    Excel,
    Pdf,
    Text
}

public class Rezervasyon
{
    public string Otel { get; set; }
    public int KisiSayisi { get; set; }
}