using System;
using System.ComponentModel;
using Castle.Windsor;

namespace xpan.AzaleaServiceBus.DependencyInjectionServiceHost
{
    internal class DependencyFactory
    {
        private readonly WindsorContainer container;

        public DependencyFactory(WindsorContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return container.Resolve(type);
        }
    }
}