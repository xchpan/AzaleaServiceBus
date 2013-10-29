using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace xpan.AzaleaServiceBus.ServiceImplementation
{
    public interface IMessageDispatcher
    {
        void OnDataAvailable(Guid registrationId, XmlElement data);
    }
}
