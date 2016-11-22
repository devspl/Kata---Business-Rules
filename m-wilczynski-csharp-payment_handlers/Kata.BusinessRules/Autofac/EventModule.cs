using System;
using System.Collections.Generic;
using Autofac;
using Kata.BusinessRules.EventHandlers;

namespace Kata.BusinessRules.Autofac
{
    public class EventModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                        .Where(x => x.IsAssignableTo<IEventHandler>())
                        .AsImplementedInterfaces();

            builder.Register<Func<Type, IEnumerable<IEventHandler>>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    var handlerType = typeof(IEventHandler<>).MakeGenericType(t);
                    var handlersCollectionType = typeof(IEnumerable<>).MakeGenericType(handlerType);
                    return (IEnumerable<IEventHandler>)ctx.Resolve(handlersCollectionType);
                };
            });
        }
    }
}