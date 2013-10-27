namespace xpan.AzaleaServiceBus.ServiceImplementation
{
    public interface ICallbackExtractor<T> where T : class
    {
        T GetCallback();
    }
}