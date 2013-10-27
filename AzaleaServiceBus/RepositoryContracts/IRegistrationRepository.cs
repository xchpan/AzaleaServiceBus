using System;
using xpan.AzaleaServiceBus.ServiceContracts;

namespace xpan.AzaleaServiceBus.RepositoryContracts
{
    public interface IRegistrationRepository
    {
        void Add(Guid registrationId, RegistrationRequest request);
        void Remove(Guid registrationId);
        bool Contains(Type dataType, Guid instanceId);
        bool Contains(Guid registrationId);
    }
}
