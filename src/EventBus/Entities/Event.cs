namespace EventBus.Entities;

public abstract class Event
{
    public DateTime TimeStamps { get; protected set; }

    protected Event()
    {
        TimeStamps = DateTime.Now;
    }
}
