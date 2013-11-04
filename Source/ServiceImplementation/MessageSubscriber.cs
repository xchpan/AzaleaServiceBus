using System;
using System.Collections.Generic;
using System.Xml;
using xpan.AzaleaServiceBus.RepositoryContracts;
using xpan.AzaleaServiceBus.ServiceContracts;

namespace xpan.AzaleaServiceBus.ServiceImplementation
{
    public class MessageSubscriber : ISubscribe
    {
        private readonly ICallbackExtractor<ISubscriberCallback> callbackExtractor;
        private readonly ISubscriptionRepository subscriptoinRepository;

        public MessageSubscriber(ISubscriptionRepository subscriptoinRepository,
            ICallbackExtractor<ISubscriberCallback> callbackExtractor)
        {
            this.subscriptoinRepository = subscriptoinRepository;
            this.callbackExtractor = callbackExtractor;
        }

        public SubscribeResult Subscribe(SubscribeRequest request)
        {
            ISubscriberCallback callback = callbackExtractor.GetCallback();
            if (subscriptoinRepository.Contains(callback))
            {
                return new SubscribeResult(ResultBase.ResultStatus.Fail, "The subscription already exists.", Guid.Empty);
            }
            subscriptoinRepository.Add(request, callback);
            return new SubscribeResult(ResultBase.ResultStatus.Success, string.Empty, new Guid());
        }

        public void Unsubscribe(Guid subscriptionId)
        {
            ISubscriberCallback callback = callbackExtractor.GetCallback();
            subscriptoinRepository.Remove(callback);
        }
    }
}