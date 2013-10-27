using System.Runtime.Serialization;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    [DataContract]
    public class ResultBase
    {
        public enum ResultStatus
        {
            Success,
            Fail
        }

        public ResultBase(ResultStatus status, string message)
        {
            Status = status;
            Message = message;
        }

        [DataMember]
        public ResultStatus Status { get; private set; }

        [DataMember]
        public string Message { get; private set; }
    }
}