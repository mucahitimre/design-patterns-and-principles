using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DesignPatternsAndPrinciplesConsole;

public class Program
{
    public static void Main(string[] args)
    {
        //setup our DI
        var serviceProvider = new ServiceCollection()
            .AddLogging(e =>
            {
                e.ClearProviders();
                e.AddConsole();
            })
            .AddScoped(typeof(IRepository<>), typeof(LocalRepository<>))
            .AddScoped(typeof(IUnitOfWorkSession), typeof(UnitOfWorkSession))
            .AddScoped(typeof(IContextHandler), typeof(ContextHandler))
            .BuildServiceProvider();

        Console.WriteLine("Hello world..");

        using (var session = serviceProvider.GetService<IUnitOfWorkSession>())
        using (var repository = session.GetRepository<Foo>())
        using (var barRepository = session.GetRepository<Bar>())
        {
            var data = repository.Get(Guid.NewGuid());

            var jackId = Guid.NewGuid();
            repository.Insert(new Foo() { Id = jackId, Name = "Jack" });
            var newData = repository.Get(jackId);
            if (newData == null)
            {
                //session.Commit();
                newData = repository.Get(jackId);
                if (newData != null)
                {
                    Console.WriteLine("Data is created after Commit.");
                }
            }

            if (newData != null)
            {
                repository.Delete(newData);
            }

            var deletedData = repository.Get(jackId);
            if (deletedData != null)
            {
                //session.Commit();
                deletedData = repository.Get(jackId);
                if (deletedData == null)
                {
                    Console.WriteLine("Data is deleted after Commit.");
                }
            }

            var elonId = Guid.NewGuid();
            repository.Insert(new Foo() { Id = elonId, Name = "Elon" });
            //session.Commit();

            var list = repository.FindAll(w => w.Id == elonId);

            barRepository.Insert(new Bar { Id = Guid.NewGuid(), Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." });
            //session.Commit();
        }

        // Eğer hiç commit yapılma ise session biterken(dispose edilirken) commit olur.

        Console.WriteLine("Bye world..");
        Console.ReadKey();
    }


    public class Foo : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class Bar : IEntity
    {
        public Guid Id { get; set; }

        public string Content { get; set; }
    }
}