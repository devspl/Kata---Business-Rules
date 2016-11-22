using System;
using Kata.BusinessRules.Events;

namespace Kata.BusinessRules.EventHandlers
{
    public class BookPaidHandler : IEventHandler<IEventOf<Payment>>
    {
        public bool CanHandle(IEventOf<Payment> @event)
        {
            var casted =  @event as PaymentMadeEvent;
            if (casted == null) return false;
            return casted.Source.PaidProduct.CategoryName == "Books";
        }

        public void HandleEvent(IEventOf<Payment> @event)
        {
            if (!CanHandle(@event)) return;
            Console.WriteLine("Generated duplicate packing slip for the royalty department.");
        }
    }
}