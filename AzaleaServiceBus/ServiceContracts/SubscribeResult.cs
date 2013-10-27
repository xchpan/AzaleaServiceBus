using System;
using System.Runtime.Serialization;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    [DataContract]
    public class SubscribeResult
    {
        public SubscribeResult(ResultBase.ResultStatus status, string message, Guid id)
        {
            Id = id;
            ResultState = new ResultBase(status, message);
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public ResultBase ResultState { get; private set; }
    }
}