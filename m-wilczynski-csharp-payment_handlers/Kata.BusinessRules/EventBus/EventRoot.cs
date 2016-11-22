using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Kata.BusinessRules.EventHandlers;
using Kata.BusinessRules.Events;

namespace Kata.BusinessRules
{
    public static class EventRoot
    {
        private static Func<Type, IEnumerable<IEventHandler>> _registeredHandlers;

        public static void RegisterContainer(IContainer container)
        {
            if (_registeredHandlers != null) return;
            if (container == null) throw new ArgumentNullException(nameof(container));
            _registeredHandlers = container.Resolve<Func<Type, IEnumerable<IEventHandler>>>();
        }
        
        public static void RaiseEventOf<TSource>(IEventOf<TSource> @event) where TSource : EventSource
        {
            if (@event == null) return;
            
            var handlers = _registeredHandlers(typeof(TSource)).OfType<IEventHandler<IEventOf<TSource>>>();
            foreach (var handler in handlers.Where(h => h.CanHandle(@event)))
            {
                handler.HandleEvent(@event);
            }
        }
    }
}