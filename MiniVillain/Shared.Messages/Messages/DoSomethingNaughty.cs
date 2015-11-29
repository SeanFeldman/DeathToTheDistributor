namespace Shared.Messages
{
    using NServiceBus;

    public class DoSomethingNaughty : ICommand
    {
        public string Data { get; set; }
    }
}
