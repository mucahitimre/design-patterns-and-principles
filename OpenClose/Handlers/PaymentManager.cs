namespace OpenClose.Handlers;

public class PaymentManager : IPaymentManager
{
    private readonly IEnumerable<IPaymentType> _paymentTypes;

    public PaymentManager(IEnumerable<IPaymentType> paymentTypes)
    {
        _paymentTypes = paymentTypes;
    }

    public IPaymentType GetCurrentPaymentType(ICartContext cartContext)
    {
        var rdn = new Random();
        var currentPaymentTypeIndex = rdn.Next(0, _paymentTypes.Count());
        cartContext.SelectedPaymentType = currentPaymentTypeIndex;

        var currentPaymentType = _paymentTypes.ToArray()[cartContext.SelectedPaymentType];

        return currentPaymentType;
    }
}
