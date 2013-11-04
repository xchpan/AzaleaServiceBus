using System;
using System.ServiceModel;
using System.Xml;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    [ServiceContract]
    public interface IPublish
    {
        [OperationContract]
        RegistrationResult Register(RegistrationRequest request);

        [OperationContract]
        void Unregister(Guid registratonId);

        [OperationContract]
        ResultBase Publish(Guid registrationId, XmlElement serializedObject);
    }
}