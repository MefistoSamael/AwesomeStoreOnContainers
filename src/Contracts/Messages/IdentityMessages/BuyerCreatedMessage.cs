namespace Contracts.Messages.IdentityMessages;

public class BuyerCreatedMessage : Message
{
    required public string BuyerId { get; set; }

    required public string BuyerEmail { get; set; }
}
