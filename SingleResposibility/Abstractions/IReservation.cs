namespace SingleResposibility.Abstractions;

public interface IReservation
{
    int HotelId { get; set; }
    int NumberOfPersons { get; set; }
    DateTime StartDate { get; set; }
    DateTime EndDate { get; set; }
}