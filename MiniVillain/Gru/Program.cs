﻿namespace Gru
{
    using System;
    using System.Threading.Tasks;
    using NServiceBus;
    using Shared.Messages;

    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            var configuration = new BusConfiguration();
            configuration.EndpointName("Gru");
            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();
            configuration.SendFailedMessagesTo("error");


            var minionEndpoint = new EndpointName("Minion");
            configuration.Routing().UnicastRoutingTable.AddStatic(typeof(DoSomethingNaughty), minionEndpoint);
            configuration.Routing().UseFileBasedEndpointInstanceLists().LookForFilesIn(@".\");

            var endpoint = await Endpoint.Start(configuration);
            var busContext = endpoint.CreateBusContext();

            Console.WriteLine("Press enter to send a message");
            Console.WriteLine("Press any key to exit");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key != ConsoleKey.Enter)
                {
                    await endpoint.Stop();
                    return;
                }

                Console.WriteLine("Commanding to do something naughty.");
                await busContext.Send<DoSomethingNaughty>(m => m.Data = "Go minion, go!");
            }
        }
    }
}
