namespace EventBus.Domain.Abstractions;

public interface IEventHandler<in TEvent> : IEventHandler
{
    Task Handle(TEvent @event);
}
public interface IEventHandler
{

}
