using System;
using Kata.BusinessRules.Events;

namespace Kata.BusinessRules.EventHandlers
{
    public class MembershipActivationPaidHandler : IEventHandler<IEventOf<Payment>>
    {
        public bool CanHandle(IEventOf<Payment> @event)
        {
            var casted =  @event as PaymentMadeEvent;
            if (casted == null) return false;
            return casted.Source.PaidProduct.CategoryName == "Memberships" 
                && casted.Source.PaidProduct.SubcategoryName == "Activation";
        }

        public void HandleEvent(IEventOf<Payment> @event)
        {
            if (!CanHandle(@event)) return;
            Console.WriteLine($"Membership for {@event.Source.PaidProduct.Name} activated. ");
        }
    }
}