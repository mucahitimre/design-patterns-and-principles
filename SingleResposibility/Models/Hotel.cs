using SingleResposibility.Abstractions;

namespace SingleResposibility.Models;

public class Hotel : IHotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int VendorId { get; set; }
}
