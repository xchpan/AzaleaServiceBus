using System;
using System.Xml;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    public interface IPublish
    {
        RegistrationResult Register(RegistrationRequest request);
        void Unregister(Guid registratonId);

        void Publish(Guid registrationId, XmlElement serializedObject);
    }
}
