using System;
using System.ServiceModel;
using System.Threading;
using System.Xml;
using xpan.AzaleaServiceBus.ServiceContracts;

namespace xpan.AzaliaServiceBus.SamplePublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to exist the temprature publisher...");

            var category = new Guid();
            var id = new Guid();
            using (var factory = new ChannelFactory<IPublish>("publisher"))
            {
                var channel = factory.CreateChannel();
                var registration = channel.Register(new RegistrationRequest(typeof (Temperature), category, id, string.Empty));
                do
                {
                    channel.Publish(registration.Id, new XmlElement());
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                } while (!Console.KeyAvailable);
            }
        }
    }
}
