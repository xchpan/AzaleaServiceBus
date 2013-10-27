using System.Collections.Generic;
using xpan.AzaleaServiceBus.ServiceContracts;

namespace xpan.AzaleaServiceBus.RepositoryContracts
{
    public interface ISubscriptoinRepository : IDictionary<SubscribeRequest, ISubscriberCallback>
    {
        bool Contains(ISubscriberCallback callback);
        void Remove(ISubscriberCallback callback);
    }
}