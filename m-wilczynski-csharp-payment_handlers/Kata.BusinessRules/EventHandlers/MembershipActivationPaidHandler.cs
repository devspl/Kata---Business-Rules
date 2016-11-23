using System;
using Kata.BusinessRules.Events;
using Kata.BusinessRules.Models;

namespace Kata.BusinessRules.EventHandlers
{
    public class MembershipActivationPaidHandler : IEventHandler<IEventOf<Payment>>
    {
        public bool CanHandle(IEventOf<Payment> @event)
        {
            var casted =  @event as PaymentMadeEvent;
            if (casted == null) return false;
            var product = casted.Source.PaidProduct as MembershipProduct;
            return product != null && product.PurchaseAction == MembershipPurchaseAction.Activation;
        }

        public void HandleEvent(IEventOf<Payment> @event)
        {
            if (!CanHandle(@event)) return;
            Console.WriteLine($"Membership for {@event.Source.PaidProduct.Name} activated. ");
        }
    }
}