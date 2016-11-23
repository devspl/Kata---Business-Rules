using System;
using System.Collections.Generic;
using Autofac;
using Kata.BusinessRules.EventHandlers;
using Kata.BusinessRules.Events;

namespace Kata.BusinessRules.Autofac
{
    public class EventModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookPaidHandler>().As<IEventHandler<IEventOf<Payment>>>();
            builder.RegisterType<MembershipActivationPaidHandler>().As<IEventHandler<IEventOf<Payment>>>();
            builder.RegisterType<MembershipPaidSendEmailHandler>().As<IEventHandler<IEventOf<Payment>>>();
            builder.RegisterType<MembershipUpgradePaidHandler>().As<IEventHandler<IEventOf<Payment>>>();
            builder.RegisterType<PhysicalProductPaidHandler>().As<IEventHandler<IEventOf<Payment>>>();

            builder.Register<Func<Type, IEnumerable<IEventHandler>>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    var handlerType = typeof(IEventHandler<>).MakeGenericType(t);
                    var handlersCollectionType = typeof(IEnumerable<>).MakeGenericType(handlerType);
                    var results = (IEnumerable<IEventHandler>)ctx.Resolve(handlersCollectionType);
                    return results;
                };
            });
        }
    }
}