namespace OpenClose.Handlers;

public class PayAtDoorPaymentType : IPaymentType
{
    public IPaymentResponse Pay(ICartContext cartContext)
    {
        return new DefaultPaymentResponse("These products do not support cash on delivery");
    }
}
