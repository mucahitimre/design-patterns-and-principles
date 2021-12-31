using SingleResposibility.Abstractions;

namespace SingleResposibility.Providers;

public class EmailSender : IEmailSender
{
    public void SendAsyncEmail(IClient client, IReservation reservation)
    {
        // todo send email..
    }
}
