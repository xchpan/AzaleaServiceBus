using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    [DataContract]
    public class SubscribeRequest
    {
        [DataMember]
        public Type DateType { get; private set; }

        [DataMember]
        public List<string> XPathPredicts { get; private set; }
    }
}