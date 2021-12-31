namespace SingleResposibility.Abstractions;

public interface IPrinterDataProvider
{
    string Key { get; }

    byte[] GetData(IReservation reservation);
}
