using SingleResposibility.Models;

namespace SingleResposibility.Abstractions;

public interface IHotelFinder
{
    List<IHotel> Search(SearchModel model);
}
