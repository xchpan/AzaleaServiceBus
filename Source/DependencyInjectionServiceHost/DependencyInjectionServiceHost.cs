using System;
using System.ServiceModel;
using Castle.Windsor;

namespace xpan.AzaleaServiceBus.DependencyInjectionServiceHost
{
    public class DependencyInjectionServiceHost : ServiceHost
    {
        private readonly WindsorContainer container;

        public DependencyInjectionServiceHost(WindsorContainer container, Type serviceType)
            : base(serviceType)
        {
            this.container = container;
        }

        public DependencyInjectionServiceHost(WindsorContainer container, Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.container = container;
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            Description.Behaviors.Add(new DependencyInjectionServiceBehavior(container));
            base.OnOpen(timeout);
        }
    }
}