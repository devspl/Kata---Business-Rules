using System;

namespace Kata.BusinessRules.Events
{
    public abstract class EventSource
    {
        protected void RaiseEvent(IEvent @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));
            EventRoot.RaiseEvent(@event);
        }
    }
}