using System;

namespace KataBlackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Console.WriteLine("Welcome to BlackJack!");
            Player player = new Player();
            player.Play();
        }
    }
}