namespace Shared
{
    using System;

    public static class ColouredConsole
    {
        public static void WriteLine(string what)
        {
            var saved = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(what);
            Console.ForegroundColor = saved;
        }
    }
}