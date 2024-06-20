namespace Contracts.Events.IdentityEvents;

public class BuyerCreatedEvent : Event
{
    required public string BuyerId { get; set; }

    required public string BuyerEmail { get; set; }
}
