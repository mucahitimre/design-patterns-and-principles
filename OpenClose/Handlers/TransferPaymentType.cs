namespace OpenClose.Handlers;

public class TransferPaymentType : IPaymentType
{
    public IPaymentResponse Pay(ICartContext cartContext)
    {
        return new DefaultPaymentResponse();
    }
}
