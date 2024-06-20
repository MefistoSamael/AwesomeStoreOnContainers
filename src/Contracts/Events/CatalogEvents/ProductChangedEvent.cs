namespace Contracts.Events.CatalogEvents;

public class ProductChangedEvent
{
    required public string ProductId { get; set; }

    required public string? NewProductName { get; set; }

    required public string OldProductName { get; set; }

    required public int? NewPrice { get; set; }

    required public int OldPrice { get; set; }

    required public string? NewImageUri { get; set; }

    required public string OldImageUri { get; set; }

    required public int? NewStockCount { get; set; }

    required public int OldStockCount { get; set; }
}
