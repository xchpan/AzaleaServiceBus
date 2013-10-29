using System;
using Castle.Windsor;

namespace xpan.AzaleaServiceBus.DependencyInjectionServiceHost
{
    internal class DependencyFactory
    {
        private static readonly WindsorContainer container = new WindsorContainer();

        public static IWindsorContainer Container
        {
            get { return container; }
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            return Container.Resolve(type);
        }
    }
}