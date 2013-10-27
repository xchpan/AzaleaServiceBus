using System.ServiceModel;
using xpan.AzaleaServiceBus.ServiceImplementation;

namespace ContextUtilities
{
    public class CallbackExtrator<T> : ICallbackExtractor<T> where T : class
    {
        public T GetCallback()
        {
            return OperationContext.Current.GetCallbackChannel<T>();
        }
    }
}