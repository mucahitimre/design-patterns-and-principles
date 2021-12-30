using SingleResposibility.Abstractions;

namespace SingleResposibility.Providers;

public class PdfPrintProvider : IPrinterDataProvider
{
    public const string KEY = "Pdf";

    public string Key => KEY;

    public byte[] GetData(IReservation reservation)
    {
        // create byte[] 

        return default;
    }
}
