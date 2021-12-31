namespace SingleResposibility.Abstractions;

public interface IHotel
{
    int Id { get; set; }
    string Name { get; set; }
    int Price { get; set; }
    int VendorId { get; set; }
}
