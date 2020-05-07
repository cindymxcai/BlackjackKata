using System;

namespace Blackjack
{
    public class ConsoleReader : IConsoleReader
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}