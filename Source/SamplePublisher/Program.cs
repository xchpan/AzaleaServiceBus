using System;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
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
                    channel.Publish(registration.Id, ToXmlElement(getNewTemperature()));
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                } while (!Console.KeyAvailable);
            }
        }

        private static int index = 0;
        private static int max = 200;

        private static Temperature getNewTemperature()
        {
            var x = ++index%max - max/2;
            return new Temperature()
            {
                Unit = "F",
                Value = 70 + x*0.08
            };
        }

        private static XmlElement ToXmlElement(object obj)
        {
            var doc = new XmlDocument();
            var serializer = new XmlSerializer(obj.GetType());
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                doc.Load(stream);
                return doc.DocumentElement;
            }
        }
    }
}
