using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UnitOfWork;

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
            .AddTransient(typeof(IRepository<>), typeof(LocalRepository<>))
            .AddTransient(typeof(IUnitOfWorkSession), typeof(UnitOfWorkSession))
            .BuildServiceProvider();

        Console.WriteLine("Hello world..");

        var session = serviceProvider.GetService<IUnitOfWorkSession>();
        var repository = session.GetRepository<Foo>();

        var data = repository.Get(Guid.NewGuid());

        var newId = Guid.NewGuid();
        repository.Insert(new Foo() { Id = newId, Name = "dememe" });
        var newData = repository.Get(newId);
        if (newData == null)
        {
            session.Commit();
            newData = repository.Get(newId);
        }

        repository.Delete(newData);

        var deletedData = repository.Get(newId);
        if (deletedData != null)
        {
            //session.Commit();
            session.Complate();
            deletedData = repository.Get(newId);
        }

        var new2Id = Guid.NewGuid();
        repository.Insert(new Foo() { Id = new2Id, Name = "example" });
        session.Commit();

        repository = session.GetRepository<Foo>();
        var list = repository.FindAll(w => w.Id == new2Id);

        Console.WriteLine("Bye world..");
        Console.ReadKey();
    }


    public class Foo : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}