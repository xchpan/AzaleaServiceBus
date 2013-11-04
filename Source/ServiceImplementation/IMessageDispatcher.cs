using System;
using System.Xml;

namespace xpan.AzaleaServiceBus.ServiceImplementation
{
    public interface IMessageDispatcher
    {
        void OnDataAvailable(Guid registrationId, XmlElement data);
    }
}