using System;
using System.Runtime.Serialization;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    [DataContract]
    public class RegistrationRequest
    {
        public RegistrationRequest(Type dataType, Guid category, Guid instance, string message)
        {
            DataType = dataType;
            Instance = instance;
            Message = message;
        }

        [DataMember]
        public Type DataType { get; private set; }

        [DataMember]
        public Guid Instance { get; private set; }

        [DataMember]
        public string Message { get; private set; }
    }
}