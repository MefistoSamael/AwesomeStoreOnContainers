namespace Contracts.Events.IdentityEvents;

public class BuyerDeletedEvent : Event
{
    required public string BuyerId { get; set; }
}
