using System;
using Kata.BusinessRules.Events;

namespace Kata.BusinessRules.EventHandlers
{
    public class PhysicalProductPaidHandler : IEventHandler<IEventOf<Payment>>
    {
        public bool CanHandle(IEventOf<Payment> @event)
        {
            var casted =  @event as PaymentMadeEvent;
            if (casted == null) return false;
            return casted.Source.PaidProduct.IsPhysical;
        }

        public void HandleEvent(IEventOf<Payment> @event)
        {
            if (!CanHandle(@event)) return;
            Console.WriteLine("Generated slip.");
        }
    }
}