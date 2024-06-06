using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.EventHandler;

public interface IEventHandler<in TEvent> : IEventHandler
{
    Task Handle(TEvent @event);
}
public interface IEventHandler
{

}
