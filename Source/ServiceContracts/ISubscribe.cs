using System;
using System.ServiceModel;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    [ServiceContract(CallbackContract = typeof (ISubscriberCallback))]
    public interface ISubscribe
    {
        [OperationContract]
        SubscribeResult Subscribe(SubscribeRequest request);

        [OperationContract]
        void Unsubscribe(Guid subscriptionId);
    }
}