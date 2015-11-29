namespace Minion
{
    using System.Configuration;
    using System.Threading.Tasks;
    using NServiceBus;
    using Shared;
    using Shared.Messages;

    public class DoSomethingNaughtyHandler : IHandleMessages<DoSomethingNaughty>
    {
        public async Task Handle(DoSomethingNaughty message, IMessageHandlerContext context)
        {
            ColouredConsole.WriteLine("Para tu, Gru!");
            await context.Reply<Dun>(m => m.By = MinionName);
        }

        private static string MinionName => ConfigurationManager.AppSettings["minion.name"];
    }
}