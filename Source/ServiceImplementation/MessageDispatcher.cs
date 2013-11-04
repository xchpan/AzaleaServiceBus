using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using xpan.AzaleaServiceBus.RepositoryContracts;
using xpan.AzaleaServiceBus.ServiceContracts;

namespace xpan.AzaleaServiceBus.ServiceImplementation
{
    public class MessageDispatcher : IMessageDispatcher
    {
        private readonly IRegistrationRepository registrationRepository;
        private readonly ISubscriptionRepository subscriptionRepository;

        public MessageDispatcher(IRegistrationRepository registrationRepository,
            ISubscriptionRepository subscriptionRepository)
        {
            this.registrationRepository = registrationRepository;
            this.subscriptionRepository = subscriptionRepository;
        }

        public void OnDataAvailable(Guid registrationId, XmlElement data)
        {
            Task.Factory.StartNew(() => Dispatch(registrationId, data));
        }

        private void Dispatch(Guid registrationId, XmlElement data)
        {
            Type dataType = registrationRepository.GetDataType(registrationId);
            foreach (ISubscriberCallback callback in FindCallbacks(dataType, data))
            {
                callback.OnDataAvailable(data);
            }
        }

        private IEnumerable<ISubscriberCallback> FindCallbacks(Type dataType, XmlElement data)
        {
            foreach (SubscribeRequest request in subscriptionRepository.Keys)
            {
                if (request.DateType == dataType && MatchXPaths(request.XPathPredicts, data))
                {
                    yield return subscriptionRepository[request];
                }
            }
        }

        private bool MatchXPaths(List<string> xPaths, XmlElement data)
        {
            throw new NotImplementedException();
            ;
        }
    }
}