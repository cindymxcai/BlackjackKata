using System;
using System.Collections.Generic;

namespace KataBlackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Game game = new Game();
            
            List<Card> playerCards = new List<Card>();
            Hand playerHand = new Hand(playerCards);
            List<Card> dealerCards = new List<Card>();
            Hand dealerHand = new Hand(dealerCards);
            
            game.SetUpGame( playerHand,  dealerHand);
            game.Gameloop(playerHand, dealerHand);
          
            
        }
    }
}