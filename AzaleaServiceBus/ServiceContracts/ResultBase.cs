using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    public abstract class ResultBase
    {
        public enum ResultStatus { Success, Fail }

        public ResultStatus Status { get; private set; }
        public string Message { get; private set; }

        protected ResultBase(ResultStatus status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
