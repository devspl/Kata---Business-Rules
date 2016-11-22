using System;

namespace Kata.BusinessRules.Events
{
    public abstract class EventSource
    {
        protected void RaiseEvent<TSource>(IEventOf<TSource> @event) where TSource : EventSource
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));
            EventRoot.RaiseEventOf(@event);
        }
    }
}