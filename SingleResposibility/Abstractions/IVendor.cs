using SingleResposibility.Models;

namespace SingleResposibility.Abstractions;

public interface IVendor
{
    Task<List<IHotel>> SearchHotel(SearchModel model);
}
