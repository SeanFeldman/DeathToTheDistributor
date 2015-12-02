namespace Minion
{
    using System;
    using System.Threading.Tasks;
    using NServiceBus;
    using Shared;

    class ProgramMinion
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            var configuration = new BusConfiguration();
            configuration.EndpointName("Minion");
            #region Minion name

            // ConfigurationManager.AppSettings["minion.name"]

            #endregion
            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();
            configuration.SendFailedMessagesTo("error");

            var endpoint = await Endpoint.Start(configuration);

            ColouredConsole.WriteLine("Bello!");
            Console.WriteLine("Press any key to exit");

            Console.ReadLine();
            await endpoint.Stop();

        }
    }
}
