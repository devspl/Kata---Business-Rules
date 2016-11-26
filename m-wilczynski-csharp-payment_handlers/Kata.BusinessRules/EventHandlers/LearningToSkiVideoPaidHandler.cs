using System;
using System.Linq;
using Kata.BusinessRules.Events;
using Kata.BusinessRules.Models;

namespace Kata.BusinessRules.EventHandlers
{
    public class LearningToSkiVideoPaidHandler : IEventHandler<IEventOf<Payment>>
    {
        public bool CanHandle(IEventOf<Payment> @event)
        {
            var casted =  @event as PaymentMadeEvent;
            if (casted == null) return false;
            return casted.Source.PaidProduct.MatchingTypes.Any(prd => prd == ProductType.Video) 
                && casted.Source.PaidProduct.Name.Equals("Learning To Ski", StringComparison.CurrentCultureIgnoreCase);
        }

        public void HandleEvent(IEventOf<Payment> @event)
        {
            if (!CanHandle(@event)) return;
            Console.WriteLine("Added a free video 'First Aid' to slip.");
        }
    }
}