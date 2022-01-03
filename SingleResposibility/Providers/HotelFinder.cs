using System.Diagnostics;

namespace SingleResposibility.Providers;

public class HotelFinder : IHotelFinder
{
    private readonly IEnumerable<IVendor> _vendors;

    public HotelFinder(IEnumerable<IVendor> vendors)
    {
        _vendors = vendors;
    }

    public List<IHotel> Search(SearchModel model)
    {
        var reponse = new List<IHotel>();
        var timer = new Stopwatch();
        timer.Start();
        Parallel.ForEach(_vendors, async item => reponse.AddRange(await item.SearchHotel(model)));
        timer.Stop();

        Console.WriteLine(timer.ElapsedMilliseconds);

        //1........ 10sn
        //2..... 5sn
        //3..1sn
        //3.................25
        var response = reponse.GroupBy(e => e.Id).Select(e => new Hotel
        {
            Id = e.Key,
            Name = e.First().Name,
            Price = e.Min(e => e.Price),
            VendorId = e.Min(e => e.VendorId)
        }).ToList();

        return reponse;
    }
}
