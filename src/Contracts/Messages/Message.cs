namespace Contracts.Messages;

public abstract class Message
{
    public DateTime TimeStamp { get; protected set; }

    protected Message()
    {
        TimeStamp = DateTime.Now;
    }
}
