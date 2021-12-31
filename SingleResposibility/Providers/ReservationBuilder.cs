using SingleResposibility.Abstractions;

namespace SingleResposibility.Providers;

public class ReservationBuilder : IReservationBuilder
{
    public bool Build(IClient client, IReservation reservation)
    {
        return true;
    }
}
