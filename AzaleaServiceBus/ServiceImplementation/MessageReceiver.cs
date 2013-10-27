using System;
using System.Xml;
using xpan.AzaleaServiceBus.RepositoryContracts;
using xpan.AzaleaServiceBus.ServiceContracts;

namespace xpan.AzaleaServiceBus.ServiceImplementation
{
    public class MessageReceiver : IPublish
    {
        private readonly IRegistrationRepository registrationRepository;

        public MessageReceiver(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        public RegistrationResult Register(RegistrationRequest request)
        {
            if (registrationRepository.Contains(request.DataType, request.Instance))
            {
                return new RegistrationResult(ResultBase.ResultStatus.Fail, "Registration already exists.", Guid.Empty);
            }
            var guid = new Guid();
            registrationRepository.Add(guid, request);
            return new RegistrationResult(ResultBase.ResultStatus.Success, string.Empty, guid);
        }

        public void Unregister(Guid registratonId)
        {
            registrationRepository.Remove(registratonId);
        }

        public ResultBase Publish(Guid registrationId, XmlElement serializedObject)
        {
            if (registrationRepository.Contains(registrationId))
            {
                RaiseDataAvailableEvent(registrationId, serializedObject);
                return new ResultBase(ResultBase.ResultStatus.Success, string.Empty);
            }
            return new ResultBase(ResultBase.ResultStatus.Fail, "The RegistrationId doesn't exist.");
        }

        public event Action<Guid, XmlElement> OnDataAvailable;

        private void RaiseDataAvailableEvent(Guid guid, XmlElement data)
        {
            Action<Guid, XmlElement> onDataAvailable = OnDataAvailable;
            if (onDataAvailable != null)
            {
                onDataAvailable(guid, data);
            }
        }
    }
}