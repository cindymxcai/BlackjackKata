using System;

namespace KataBlackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Console.WriteLine("Welcome to BlackJack!");
            deck.Add( );
            Card card = new Card(Card.Value.Eight, Card.Suit.Clubs);
            Console.WriteLine((int)card._Value);
        }
    }
}