namespace OpenClose.Models;

public class CreditCartPaymentResponse : DefaultPaymentResponse, IPaymentResponse
{
    public CreditCartPaymentResponse()
    {
    }

    public CreditCartPaymentResponse(string message, string bankResponse = null)
        : base(message)
    {
        if (bankResponse != null)
        {
            Message = string.Concat(Message, $"BankResponse: {bankResponse}");
        }
    }
}
