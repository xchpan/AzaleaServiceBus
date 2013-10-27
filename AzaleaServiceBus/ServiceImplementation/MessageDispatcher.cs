using System;
using System.Threading.Tasks;
using System.Xml;
using xpan.AzaleaServiceBus.RepositoryContracts;

namespace xpan.AzaleaServiceBus.ServiceImplementation
{
    public class MessageDispatcher : IDisposable
    {
        private readonly MessageReceiver publisher;
        private readonly IRegistrationRepository registrationRepository;
        private readonly MessageSubscriber subscriber;

        public MessageDispatcher(IRegistrationRepository registrationRepository,
            MessageSubscriber subscriber,
            MessageReceiver publisher)
        {
            this.registrationRepository = registrationRepository;
            this.subscriber = subscriber;
            this.publisher = publisher;
            publisher.OnDataAvailable -= OnDataAvailable;
        }

        public void Dispose()
        {
            publisher.OnDataAvailable -= OnDataAvailable;
            GC.SuppressFinalize(this);
        }

        private void OnDataAvailable(Guid registrationId, XmlElement data)
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