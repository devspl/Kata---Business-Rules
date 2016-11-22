using System;
using Autofac;
using Kata.BusinessRules.Autofac;

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

            Console.ReadKey();
        }
    }
}
