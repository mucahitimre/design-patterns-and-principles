namespace OpenClose.Handlers;

public class CreditCartPaymentType : IPaymentType
{
    public IPaymentResponse Pay(ICartContext cartContext)
    {
        return new CreditCartPaymentResponse();
    }
}
