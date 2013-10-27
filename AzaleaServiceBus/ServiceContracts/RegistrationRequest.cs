using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    public class RegistrationRequest
    {
        public Type DataType { get; private set; }
        public Guid Instance { get; private set; }
        public string Message { get; private set; }

        public RegistrationRequest(Type dataType, Guid category, Guid instance, string message)
        {
            DataType = dataType;
            Instance = instance;
            Message = message;
        }
    }
}
