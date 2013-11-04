using System;
using System.Xml;
using xpan.AzaleaServiceBus.ServiceContracts;

namespace xpan.AzaleaServiceBus.ConsoleHost
{
    public class ServiceBusService : IPublish, ISubscribe
    {
        private readonly IPublish publisher;
        private readonly ISubscribe subscriber;

        public ServiceBusService(IPublish publisher, ISubscribe subscriber)
        {
            this.publisher = publisher;
            this.subscriber = subscriber;
        }

        RegistrationResult IPublish.Register(RegistrationRequest request)
        {
            return publisher.Register(request);
        }

        void IPublish.Unregister(Guid registratonId)
        {
            publisher.Unregister(registratonId);
        }

        ResultBase IPublish.Publish(Guid registrationId, XmlElement serializedObject)
        {
            return publisher.Publish(registrationId, serializedObject);
        }

        SubscribeResult ISubscribe.Subscribe(SubscribeRequest request)
        {
            return subscriber.Subscribe(request);
        }

        void ISubscribe.Unsubscribe(Guid subscriptionId)
        {
            subscriber.Unsubscribe(subscriptionId);
        }
    }
}