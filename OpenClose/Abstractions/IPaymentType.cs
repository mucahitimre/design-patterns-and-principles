namespace OpenClose.Abstractions;

public interface IPaymentType
{
    IPaymentResponse Pay(ICartContext cartContext);
}
