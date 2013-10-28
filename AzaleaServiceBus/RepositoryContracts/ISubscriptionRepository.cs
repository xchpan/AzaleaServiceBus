using System.Collections.Generic;
using xpan.AzaleaServiceBus.ServiceContracts;

namespace xpan.AzaleaServiceBus.RepositoryContracts
{
    public interface ISubscriptionRepository
    {
        IEnumerable<SubscribeRequest> Keys { get; }
        ISubscriberCallback this[SubscribeRequest request] { get; }
        bool Contains(ISubscriberCallback callback);
        void Add(SubscribeRequest request, ISubscriberCallback callback);
        void Remove(ISubscriberCallback callback);
    }
}