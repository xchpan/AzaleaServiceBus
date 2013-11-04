using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ContextUtilities;
using xpan.AzaleaServiceBus.InMemoryRepositories;
using xpan.AzaleaServiceBus.RepositoryContracts;
using xpan.AzaleaServiceBus.ServiceContracts;
using xpan.AzaleaServiceBus.ServiceImplementation;

namespace xpan.AzaleaServiceBus.ConsoleHost
{
    internal class ServiceBusHost : IDisposable
    {
        private readonly WindsorContainer container;
        private DependencyInjectionServiceHost.DependencyInjectionServiceHost host;

        public ServiceBusHost()
        {
            container = new WindsorContainer();
        }

        void IDisposable.Dispose()
        {
            host.Close();
        }

        public void Configure()
        {
            container.Register(
                Component.For<IRegistrationRepository>().ImplementedBy<RegistrationRepository>());
            container.Register(Component.For<IMessageDispatcher>().ImplementedBy<MessageDispatcher>());
            container.Register(
                Component.For<ISubscriptionRepository>().ImplementedBy<SubscriptionRepository>());
            container.Register(
                Component.For<ICallbackExtractor<ISubscriberCallback>>()
                    .ImplementedBy<CallbackExtrator<ISubscriberCallback>>());
            container.Register(Component.For<IPublish>().ImplementedBy<MessageReceiver>());
            container.Register(Component.For<ISubscribe>().ImplementedBy<MessageSubscriber>());
        }

        public void Open()
        {
            host = new DependencyInjectionServiceHost.DependencyInjectionServiceHost(container,
                typeof (ServiceBusService));
            host.Open();
        }

        public void Close()
        {
            host.Close();
        }
    }
}