using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    public class SubscribeResult : ResultBase
    {
        public Guid Id { get; private set; }

        public SubscribeResult(ResultBase.ResultStatus status, string message, Guid id)
            : base(status, message)
        {
            Id = id;
        }
    }
}
