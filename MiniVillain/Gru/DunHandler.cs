namespace Gru
{
    using System.Threading.Tasks;
    using NServiceBus;
    using Shared;
    using Shared.Messages;

    public class DunHandler : IHandleMessages<Dun>
    {
        public Task Handle(Dun message, IMessageHandlerContext context)
        {
            ColouredConsole.WriteLine($"Good minion, {message.By}.");
            return Task.FromResult(0);
        }
    }
}