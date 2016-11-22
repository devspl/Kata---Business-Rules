using System;

namespace Kata.BusinessRules.Events
{
    public class PaymentMadeEvent : IEventOf<Payment>
    {
        public Payment Source { get; }
        public PaymentMadeEvent(Payment payment)
        {
            if (payment == null)
                throw new ArgumentNullException(nameof(payment));
            Source = payment;
        }
    }
}