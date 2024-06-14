namespace Contracts;

public class PriceChangedEvent
{
    required public string ProductId { get; set; }

    required public string ProductName { get; set; }

    required public int NewPrice { get; set; }

    required public int OldPrice { get; set; }
}
