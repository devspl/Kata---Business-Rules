using Kata.BusinessRules.Events;

namespace Kata.BusinessRules.EventHandlers
{
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        void HandleEvent(TEvent @event);
    }
}