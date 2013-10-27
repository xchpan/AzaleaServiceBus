using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xpan.AzaleaServiceBus.ServiceContracts
{
    public class RegistrationResult : ResultBase
    {
        public Guid Id { get; private set; }

        public RegistrationResult(ResultBase.ResultStatus status, string message, Guid id)
            : base(status, message)
        {
            Id = id;
        }
    }
}
