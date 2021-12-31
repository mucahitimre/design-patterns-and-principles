namespace SingleResposibility.Abstractions;

public interface IClient
{
    int Id { get; set; }

    string Name { get; set; }

    string Email { get; set; }
}
