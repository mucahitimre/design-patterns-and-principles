namespace OpenClose.Abstractions;

public interface IPaymentResponse
{
    bool IsSuccess { get; set; }

    string Message { get; set; }
}
