using Kata.BusinessRules.Events;

namespace Kata.BusinessRules.EventHandlers
{
    public interface IEventHandler<TEvent> : IEventHandler where TEvent : IEvent
    {
        bool CanHandle(TEvent @event);
        void HandleEvent(TEvent @event);
    }

    public interface IEventHandler {}
}