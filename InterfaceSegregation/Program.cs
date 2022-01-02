using InterfaceSegregation.Abstractions;
using InterfaceSegregation.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace InterfaceSegregation
{
    public class Program
    {
        private static void Main(string[] args)
        {
            /*
             * Burada IEditor her editörün yaptığı ortak işleri taahhüt eder, 
                ve diğer editor tipleri için farklı işler olcağından dolayı burada işleri interfaceler ile ayırdık, 
                yani her editör kendisine ait olmayan işleri implement etmemiş olacaktır.
             */

            var ioc = new ServiceCollection()
                .AddTransient<IWebEditor, WebEditor>()
                .AddTransient<INewsEditor, NewsEditor>()
                .BuildServiceProvider();

            var webEditor = ioc.GetService<IWebEditor>();
            var newsEditor = ioc.GetService<INewsEditor>();

            var webContent = webEditor.BuildContent();
            webEditor.CreateSearchKeywords(webContent);

            var newsContent = newsEditor.BuildContent();
            newsEditor.PrepareDay(newsContent);

            Console.WriteLine("Hello World!");
        }
    }
}
