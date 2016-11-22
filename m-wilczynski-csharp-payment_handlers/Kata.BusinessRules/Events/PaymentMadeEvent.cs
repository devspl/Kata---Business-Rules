using System;

namespace Kata.BusinessRules.Events
{
    public class PaymentMadeEvent : IEventOf<Payment>
    {
        public readonly Payment PaymentMade;
        public PaymentMadeEvent(Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));
            PaymentMade = payment;
        }
    }
}