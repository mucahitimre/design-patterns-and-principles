namespace OpenClose.Abstractions;

public interface IPaymentManager
{
    IPaymentType GetCurrentPaymentType(ICartContext cartContext);
}
