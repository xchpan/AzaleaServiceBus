using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    public interface ISubscribe
    {
        SubscribeResult Subscribe(SubscribeRequest request);
        void Unsubscribe(Guid subscriptionId);

        void OnDataAvailable(XmlElement serializedObject);
    }

}
