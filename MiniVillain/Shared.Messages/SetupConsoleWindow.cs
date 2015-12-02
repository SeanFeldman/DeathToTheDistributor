namespace Shared
{
    using System;
    using System.Configuration;
    using NServiceBus;
    using NServiceBus.Settings;

    class SetupConsoleWindow : IWantToRunBeforeConfigurationIsFinalized
    {
        public void Run(SettingsHolder settings)
        {

            Console.Title = ConfigurationManager.AppSettings["minion.name"] ?? "Gru";
            Console.SetWindowSize(50, 30);
            Console.SetWindowPosition(0,0);
        }
    }
}