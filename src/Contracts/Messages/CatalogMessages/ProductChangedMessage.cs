namespace Contracts.Messages.CatalogMessages;

public class ProductChangedMessage
{
    required public string ProductId { get; set; }

    required public string ProductName { get; set; }

    required public int Price { get; set; }

    required public string ImageUri { get; set; }

    required public int StockCount { get; set; }
}
