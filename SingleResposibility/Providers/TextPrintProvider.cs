using SingleResposibility.Abstractions;

namespace SingleResposibility.Providers;

public class TextPrintProvider : IPrinterDataProvider
{
    public const string KEY = "Text";

    public string Key => KEY;

    public byte[] GetData(IReservation reservation)
    {
        // create byte[] 

        return default;
    }
}
