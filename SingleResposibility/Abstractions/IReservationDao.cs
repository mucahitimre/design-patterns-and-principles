namespace SingleResposibility.Abstractions;

internal interface IReservationDao
{
    void Insert(IClient client, IReservation reservation);
}
