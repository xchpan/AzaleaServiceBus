using System;
using System.Collections.Generic;
using System.Linq;
using xpan.AzaleaServiceBus.RepositoryContracts;
using xpan.AzaleaServiceBus.ServiceContracts;

namespace xpan.AzaleaServiceBus.InMemoryRepositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly Dictionary<Guid, RegistrationRequest> registrations =
            new Dictionary<Guid, RegistrationRequest>();

        public void Add(Guid registrationId, RegistrationRequest request)
        {
            registrations.Add(registrationId, request);
        }

        public void Remove(Guid registrationId)
        {
            registrations.Remove(registrationId);
        }

        public bool Contains(Type dataType, Guid instanceId)
        {
            return
                registrations.Values.FirstOrDefault(r => r.DataType == dataType && r.Instance == instanceId) != null;
        }

        public bool Contains(Guid registrationId)
        {
            return registrations.ContainsKey(registrationId);
        }

        public Type GetDataType(Guid registrationId)
        {
            return registrations[registrationId].DataType;
        }
    }
}