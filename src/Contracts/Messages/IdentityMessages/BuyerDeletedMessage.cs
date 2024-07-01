namespace Contracts.Messages.IdentityMessages;

public class BuyerDeletedMessage : Message
{
    required public string BuyerId { get; set; }
}
