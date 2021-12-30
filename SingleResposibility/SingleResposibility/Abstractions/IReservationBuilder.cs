namespace SingleResposibility.Abstractions;

internal interface IReservationBuilder
{
    bool Build(IClient client, IReservation reservation);
}
