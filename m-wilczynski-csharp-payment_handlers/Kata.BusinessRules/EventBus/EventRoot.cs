using System;
using Autofac;
using Kata.BusinessRules.EventBus;
using Kata.BusinessRules.Events;

namespace Kata.BusinessRules
{
    public static class EventRoot
    {
        private static IContainer _container;
        private static IEventBus _eventBus;

        public static void RegisterContainer(IContainer container)
        {
            if (container != null) return;
            if (container == null) throw new ArgumentNullException(nameof(container));
            _container = container;
            _eventBus = _container.Resolve<IEventBus>();
        }

        public static void RaiseEvent(IEvent @event)
        {
            if (@event == null) return;
            _eventBus.RaiseEvent(@event);
        }
    }
} 