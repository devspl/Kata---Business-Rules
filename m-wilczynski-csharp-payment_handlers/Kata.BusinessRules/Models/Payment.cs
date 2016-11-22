using System;
using Kata.BusinessRules.Events;
using Kata.BusinessRules.Models;

namespace Kata.BusinessRules 
{
    public class Payment : EventSource
    {
        public Guid Id { get; }
        public Product PaidProduct { get; }

        public Payment(Product paidProduct)
        {
            if (paidProduct == null)
                throw new ArgumentNullException(nameof(paidProduct));
            PaidProduct = paidProduct;
            Id = Guid.NewGuid();
            EventRoot.RaiseEvent(new PaymentMadeEvent(this));
        }
    }
}