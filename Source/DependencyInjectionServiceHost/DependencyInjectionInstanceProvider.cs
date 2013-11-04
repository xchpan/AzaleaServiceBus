using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Castle.Windsor;

namespace xpan.AzaleaServiceBus.DependencyInjectionServiceHost
{
    public class DependencyInjectionInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;
        private readonly DependencyFactory factory;

        public DependencyInjectionInstanceProvider(Type serviceType, WindsorContainer container)
        {
            _serviceType = serviceType;
            factory = new DependencyFactory(container);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return factory.Resolve(_serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}