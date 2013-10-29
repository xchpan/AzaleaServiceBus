using System;
using System.ServiceModel;

namespace xpan.AzaleaServiceBus.DependencyInjectionServiceHost
{
    internal class DependencyInjectionServiceHost : ServiceHost
    {
        public DependencyInjectionServiceHost(Type serviceType)
            : base(serviceType)
        {
        }

        public DependencyInjectionServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            Description.Behaviors.Add(new DependencyInjectionServiceBehavior());
            base.OnOpen(timeout);
        }
    }
}