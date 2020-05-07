namespace Blackjack
{
    public class Player : IPlayer
    {
        private readonly IConsoleReader _consoleReader;
        public Hand PlayerHand { get; }

        public Player(Hand hand, IConsoleReader consoleReader)
        {
            PlayerHand = hand;
            _consoleReader = consoleReader;
        }

        public Response getResponse()
        {
            var input = _consoleReader.GetInput();
            return input == "1" ? Response.Hit :
                input == "0" ? Response.Stay : Response.Invalid;
        }

        public bool HasBlackJack(IPlayer player)
        {
            if (PlayerHand.CalculateHandSum() != 21) return false;
            Display.Blackjack(player);
            return true;
        }

        public bool HasBusted(IPlayer player)
        {
            if (PlayerHand.CalculateHandSum() <= 21) return false;
            Display.Bust(player);
            return true;
        }
    }
}