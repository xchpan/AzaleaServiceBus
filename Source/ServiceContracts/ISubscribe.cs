using System;
using System.ServiceModel;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    [ServiceContract(CallbackContract = typeof (ISubscriberCallback))]
    public interface ISubscribe
    {
        SubscribeResult Subscribe(SubscribeRequest request);
        void Unsubscribe(Guid subscriptionId);
    }
}