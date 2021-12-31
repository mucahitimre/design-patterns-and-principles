using SingleResposibility.Abstractions;

namespace SingleResposibility.Models;

public class Vendor1 : IVendor
{
    public Task<List<IHotel>> SearchHotel(SearchModel model)
    {
        // servis bağlanıp..
        Thread.Sleep(1000);

        return Task.FromResult(new List<IHotel>()
        {
            new Hotel()
            {
                Id = 2,
                Name = "Kırmızı bahçe"
            }
        });
    }
}
