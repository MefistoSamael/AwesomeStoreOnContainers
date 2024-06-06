using EventBus.Domain.Entities;

namespace Catalog.Application.Common.Events;

public class PriceChangedEvent : Event
{
    public required string ProductId { get; set; }

    public required string ProductName { get; set; }

    public required int NewPrice { get; set; }
    
    public required int OldPrice { get; set; }
}
