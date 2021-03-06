using System;
using System.Linq;
using Kata.BusinessRules.Events;
using Kata.BusinessRules.Models;

namespace Kata.BusinessRules.EventHandlers
{
    public class MembershipPaidSendEmailHandler : IEventHandler<IEventOf<Payment>>
    {
        public bool CanHandle(IEventOf<Payment> @event)
        {
            var casted =  @event as PaymentMadeEvent;
            if (casted == null) return false;
            return casted.Source.PaidProduct.MatchingTypes.Any(prd => prd == ProductType.MembershipActivation || prd == ProductType.MembershipUpgrade);
        }

        public void HandleEvent(IEventOf<Payment> @event)
        {
            if (!CanHandle(@event)) return;
            Console.WriteLine($"Sent mail for {@event.Source.PaidProduct.Name} membership. ");
        }
    }
}