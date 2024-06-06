using EventBus.Domain.Abstractions;
using EventBus.Domain.Entities;

namespace EventBus.Domain.Interfaces;

public interface IEventBus
{
    void Publish<T>(T @event) where T : Event;

    void Subscribe<T, TH>()
        where T : Event
        where TH : IEventHandler<T>;
}
