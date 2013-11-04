using Castle.Windsor;
using xpan.AzaleaServiceBus.ServiceImplementation;

namespace xpan.AzaleaServiceBus.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var windsorContainer = new WindsorContainer();
            DependencyInjectionServiceHost.DependencyInjectionServiceHost host = new DependencyInjectionServiceHost.DependencyInjectionServiceHost(windsorContainer, typeof(MessageReceiver));
        }


    }
}
