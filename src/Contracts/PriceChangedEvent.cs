namespace Contracts;

public class PriceChangedEvent
{
    public required string ProductId { get; set; }

    public required string ProductName { get; set; }

    public required int NewPrice { get; set; }

    public required int OldPrice { get; set; }
}
