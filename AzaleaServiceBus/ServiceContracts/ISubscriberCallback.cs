using System.Xml;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    public interface ISubscriberCallback
    {
        void OnDataAvailable(XmlElement serializedObject);
    }
}