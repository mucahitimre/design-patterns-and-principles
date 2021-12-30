using SingleResposibility.Models;

namespace SingleResposibility.Abstractions;

public interface IReservationFinder
{
    List<IHotel> Search(SearchModel model);
}
