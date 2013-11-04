using System.Collections.Generic;
using System.Linq;
using xpan.AzaleaServiceBus.RepositoryContracts;
using xpan.AzaleaServiceBus.ServiceContracts;

namespace xpan.AzaleaServiceBus.InMemoryRepositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly Dictionary<SubscribeRequest, ISubscriberCallback> callbacks =
            new Dictionary<SubscribeRequest, ISubscriberCallback>();

        public bool Contains(ISubscriberCallback callback)
        {
            return callbacks.Values.Contains(callback);
        }

        public void Add(SubscribeRequest request, ISubscriberCallback callback)
        {
            callbacks.Add(request, callback);
        }

        public void Remove(ISubscriberCallback callback)
        {
            SubscribeRequest request = callbacks.SingleOrDefault(pair => pair.Value == callback).Key;
            if (request != null)
            {
                callbacks.Remove(request);
            }
        }

        public IEnumerable<SubscribeRequest> Keys
        {
            get { return callbacks.Keys.AsEnumerable(); }
        }

        public ISubscriberCallback this[SubscribeRequest request]
        {
            get { return callbacks[request]; }
        }
    }
}