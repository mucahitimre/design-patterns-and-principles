using SingleResposibility.Abstractions;

namespace SingleResposibility.Providers;

public class DefaultReservation : IReservation
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public int NumberOfPersons { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
