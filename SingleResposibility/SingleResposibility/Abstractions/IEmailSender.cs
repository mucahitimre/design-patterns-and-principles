namespace SingleResposibility.Abstractions;

public interface IEmailSender
{
    void SendAsyncEmail(IClient client, IReservation reservation);
}
