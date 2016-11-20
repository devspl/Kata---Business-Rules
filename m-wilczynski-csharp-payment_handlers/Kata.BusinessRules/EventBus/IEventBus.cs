using Kata.BusinessRules.Events;

namespace Kata.BusinessRules.EventBus
{
    public interface IEventBus
    {
        void RaiseEvent(IEvent @raisedEvent);
    }
}