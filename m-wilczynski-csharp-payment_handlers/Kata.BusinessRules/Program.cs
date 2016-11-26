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
            WireUp();

            var customer = new Customer();

            var activation = new Product { Name = "Swimmer club" };
            activation.MatchingTypes.Add(ProductType.MembershipActivation);

            new Payment(activation, customer).MakePayment();

            var book = new Product { Name = "Jungle Book" };
            book.MatchingTypes.Add(ProductType.Book);
            
            new Payment(book, customer).MakePayment();

            var video = new Product { Name = "Learning To Ski" };
            video.MatchingTypes.Add(ProductType.Physical);
            video.MatchingTypes.Add(ProductType.Video);

            new Payment(video, customer).MakePayment();

            Console.ReadKey();
        }

        private static void WireUp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<EventModule>();
            var container = builder.Build();
            EventRoot.RegisterContainer(container);
        }
    }
}
