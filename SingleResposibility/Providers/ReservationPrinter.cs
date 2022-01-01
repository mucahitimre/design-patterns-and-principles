using SingleResposibility.Abstractions;

namespace SingleResposibility.Providers;

public class ReservationPrinter : IReservationPrinter
{
    private readonly IPrinter _printer;
    private readonly IEnumerable<IPrinterDataProvider> _reservationPrinters;

    public ReservationPrinter(
        IPrinter printer,
        IEnumerable<IPrinterDataProvider> reservationPrinters)
    {
        _printer = printer;
        _reservationPrinters = reservationPrinters;
    }

    public Task<string> GetAsyncDownloadUrl(string printerType, IReservation reservation)
    {
        var provider = _reservationPrinters.FirstOrDefault(w => w.Key == printerType.Trim());
        if (provider != null)
        {
            var data = provider.GetData(reservation);

            return Task.Factory.StartNew(() => _printer.GetUrl(data));
        }

        throw new NotImplementedException($"{printerType} is not implemented.");
    }
}
