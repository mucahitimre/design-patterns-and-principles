namespace OpenClose.Models;

public class DefaultPaymentResponse : IPaymentResponse
{
    public DefaultPaymentResponse()
    {
    }

    public DefaultPaymentResponse(string message)
    {
        IsSuccess = false;
        Message = message;
    }

    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; }
}
