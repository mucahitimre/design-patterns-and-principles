namespace SingleResposibility.Abstractions;

public interface IReservationPrinter
{
    Task<string> GetAsyncDownloadUrl(string printerType, IReservation reservation);
}
