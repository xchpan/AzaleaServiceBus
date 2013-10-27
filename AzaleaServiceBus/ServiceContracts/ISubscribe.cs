using System;
using System.ServiceModel;
using System.Xml;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    [ServiceContract]
    public interface ISubscribe
    {
        SubscribeResult Subscribe(SubscribeRequest request);
        void Unsubscribe(Guid subscriptionId);

        void OnDataAvailable(XmlElement serializedObject);
    }
}