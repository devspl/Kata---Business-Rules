using System;
using Autofac;
using Kata.BusinessRules.Autofac;
using Kata.BusinessRules.Models;

namespace Kata.BusinessRules
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<EventModule>();
            var container = builder.Build();
            EventRoot.RegisterContainer(container);

            var activation = new MembershipProduct(Guid.NewGuid())
            { 
                Name = "Swimmer club" 
            };
            var customer = new Customer();
            new Payment(activation, customer).MakePayment();

            Console.ReadKey();
        }
    }
}
