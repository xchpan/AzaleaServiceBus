using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ContextUtilities;
using xpan.AzaleaServiceBus.RepositoryContracts;
using xpan.AzaleaServiceBus.ServiceContracts;
using xpan.AzaleaServiceBus.ServiceImplementation;

namespace xpan.AzaleaServiceBus.ConsoleHost
{
    class ServiceBusHost
    {
        private WindsorContainer container;
        private DependencyInjectionServiceHost.DependencyInjectionServiceHost host;

        public ServiceBusHost()
        {
            this.container = new WindsorContainer();
        }

        public void Configure()
        {
            container.Register(
                Component.For<IRegistrationRepository>().ImplementedBy<InMemoryRepositories.RegistrationRepository>());
            container.Register(Component.For<IMessageDispatcher>().ImplementedBy<MessageDispatcher>());
            container.Register(
                Component.For<ISubscriptionRepository>().ImplementedBy<InMemoryRepositories.SubscriptionRepository>());
            container.Register(
                Component.For<ICallbackExtractor<ISubscriberCallback>>()
                    .ImplementedBy<CallbackExtrator<ISubscriberCallback>>());
        }

        public void Open()
        {
            host = new DependencyInjectionServiceHost.DependencyInjectionServiceHost(container, typeof(MessageReceiver));
            host.Open();
        }

        public void Close()
        {
            host.Close();
        }
    }
}
