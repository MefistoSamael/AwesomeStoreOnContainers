namespace Contracts;

public class StockCountChangedEvent : Event
{
    required public string ProductId { get; set; }

    required public string ProductName { get; set; }

    required public int NewStockCount { get; set; }

    required public int OldStockCount { get; set; }
}
