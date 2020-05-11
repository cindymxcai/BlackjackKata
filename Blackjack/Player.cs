namespace Blackjack
{
    public class Player : IPlayer
    {
        private readonly IConsoleReader _consoleReader;
        public Hand hand { get; }
        
        public Player(Hand _hand, IConsoleReader consoleReader)
        {
            hand = _hand;
            _consoleReader = consoleReader;
        }

        public Response GetResponse()
        {
            var input = _consoleReader.GetInput();
            return input == "1" ? Response.Hit :
                input == "0" ? Response.Stay : Response.Invalid;
        }

        public bool HasBlackJack()
        {
            if (!hand.HasBlackJack()) return false;
            Display.Blackjack(this);
            return true;
        }

        public bool HasBusted()
        {
            if (!hand.HasBusted()) return false;
            Display.Bust(this);
            return true;
        }

        public void ReceiveCard(Card dealtCard)
        {
            hand.CardsInHand.Add(dealtCard);
        }
    }
}