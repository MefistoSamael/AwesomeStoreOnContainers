namespace Ordering.Domain.Enums;

public enum OrderState
{
    Configuring,
    AwaitingValidation,
    Confirmed,
    Shipped,
    Canceled,
}
