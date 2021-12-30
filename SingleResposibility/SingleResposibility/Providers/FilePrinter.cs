using SingleResposibility.Abstractions;

namespace SingleResposibility.Providers;

public class FilePrinter : IPrinter
{
    public string GetUrl(byte[] data)
    {
        return "http://www.google.com/foo.txt";
    }
}
