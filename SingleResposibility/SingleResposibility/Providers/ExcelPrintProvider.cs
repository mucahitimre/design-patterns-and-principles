using SingleResposibility.Abstractions;

namespace SingleResposibility.Providers;

public class ExcelPrintProvider : IPrinterDataProvider
{
    public const string KEY = "Excel";

    public string Key => KEY;

    public byte[] GetData(IReservation reservation)
    {
        // create byte[] 

        return default;
    }
}
