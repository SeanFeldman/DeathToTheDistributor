namespace Shared.Messages
{
    using NServiceBus;

    public class Dun : IMessage
    {
        public string By { get; set; }
    }
}