namespace SingleResposibility.Providers;

public class ReservationDao : IReservationDao
{
    public void Insert(IClient client, IReservation reservation)
    {
        // save data 
        reservation.Id = 5;
    }
}
