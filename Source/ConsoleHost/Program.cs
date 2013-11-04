using System;

namespace xpan.AzaleaServiceBus.ConsoleHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var host = new ServiceBusHost())
            {
                host.Open();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}