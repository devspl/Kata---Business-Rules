using System;
using Kata.BusinessRules.Events;
using Kata.BusinessRules.Models;

namespace Kata.BusinessRules 
{
    public class Payment : EventSource
    {
        public Guid Id { get; }
        public Product PaidProduct { get; }
        public Customer Payer { get; }

        public Payment(Product paidProduct, Customer payer)
        {
            if (paidProduct == null)
                throw new ArgumentNullException(nameof(paidProduct));
            if (payer == null)
                throw new ArgumentNullException(nameof(payer));
            PaidProduct = paidProduct;
            Payer = payer;
            Id = Guid.NewGuid();
        }

        public void MakePayment()
        {
            EventRoot.RaiseEventOf(new PaymentMadeEvent(this));
        }
    }
}