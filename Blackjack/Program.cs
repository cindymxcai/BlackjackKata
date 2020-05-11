namespace Blackjack
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var consoleReader = new ConsoleReader();
            var deck = new Deck();
            var rng = new Rng();
            var hand = new Hand();
            var playerHand = new Hand();
            var dealer = new Dealer(hand, rng);
            var player = new Player(playerHand, consoleReader);
            var blackjack = new BlackjackGame(player, dealer, deck);
            blackjack.PlayGame();
        }
    }
}