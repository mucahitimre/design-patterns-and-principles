using SingleResposibility.Abstractions;

namespace SingleResposibility.Models;

public class Vendor2 : IVendor
{
    public Task<List<IHotel>> SearchHotel(SearchModel model)
    {
        // excel import edebilir..
        Thread.Sleep(2000);

        return Task.FromResult(new List<IHotel>());
    }
}
