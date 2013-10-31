using System;
using System.ServiceModel;
using System.Xml;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    [ServiceContract]
    public interface IPublish
    {
        RegistrationResult Register(RegistrationRequest request);
        void Unregister(Guid registratonId);

        ResultBase Publish(Guid registrationId, XmlElement serializedObject);
    }
}