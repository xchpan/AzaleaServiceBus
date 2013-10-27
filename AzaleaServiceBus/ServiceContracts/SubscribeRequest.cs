using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    public class SubscribeRequest
    {
        public Type DateType { get; private set; }
        public List<string> XPathPredicts { get; private set; }
    }
}
