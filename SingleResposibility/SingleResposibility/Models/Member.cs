using SingleResposibility.Abstractions;

namespace SingleResposibility.Models;

public class Member : IClient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
