using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck : IDeck
    {
        public List<Card> DeckOfCards { get; } = new List<Card>();
        public Deck()
        {
            foreach (var suit in new List<string> {"SPADES", "HEARTS", "DIAMONDS", "CLUBS"})
            {
                foreach (var value in new List<string>{"ACE", "2", "3", "4", "5", "6", "7", "8", "9", "10", "JACK", "QUEEN", "KING"})
                {
                    DeckOfCards.Add(new Card(value, suit));
                }
                
            }
        }
    }
}