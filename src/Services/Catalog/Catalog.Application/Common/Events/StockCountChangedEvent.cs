using EventBus.Domain.Entities;

namespace Catalog.Application.Common.Events;

public class StockCountChangedEvent : Event
{
    public required string ProductId { get; set; }

    public required string ProductName { get; set; }

    public required int NewStockCount { get; set; }

    public required int OldStockCount { get; set; }
}
