using System;
using System.Threading.Tasks;
using System.Xml;
using xpan.AzaleaServiceBus.RepositoryContracts;

namespace xpan.AzaleaServiceBus.ServiceImplementation
{
    public class MessageDispatcher : IMessageDispatcher
    {
        private readonly IRegistrationRepository registrationRepository;
        private readonly MessageSubscriber subscriber;

        public MessageDispatcher(IRegistrationRepository registrationRepository,
            MessageSubscriber subscriber)
        {
            this.registrationRepository = registrationRepository;
            this.subscriber = subscriber;
        }

        public void OnDataAvailable(Guid registrationId, XmlElement data)
        {
            Task.Factory.StartNew(() => Dispatch(registrationId, data));
        }

        private void Dispatch(Guid registrationId, XmlElement data)
        {
            Type dataType = registrationRepository.GetDataType(registrationId);
            if (subscriber != null)
            {
                subscriber.OnDataAvailable(dataType, data);
            }
        }
    }
}