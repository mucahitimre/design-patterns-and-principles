namespace SingleResposibility.Abstractions;

public interface IReservationPrinter
{
    Task<string> GetDownloadUrl(string printerType, IReservation reservation);
}
