using System;
using System.Collections.Generic;
using System.Linq;
using static KataBlackjack.Card;

namespace KataBlackjack
{
    public class Deck : IDeck
    {
        public readonly List<Card> DeckOfCards = new List<Card>();
        private int _currentCard = 0;
        private static readonly Random Random = new Random();  

       

        public void Add()
        {
            foreach (Card.Suit s in Enum.GetValues((typeof(Card.Suit))))
            {
                Console.WriteLine("______________");
                foreach (Card.Value v in Enum.GetValues(typeof(Card.Value)))
                {
                    DeckOfCards.Add(new Card(v,s));
                    Console.WriteLine("Suit:" + s + "    Value:" + v);
                }
            }
        }
        
        public Card TakeTopCard()
        {
            var card = DeckOfCards.First();
            DeckOfCards.Remove(card);
            return card;        
            }

        public void Shuffle<Card>( IList<Card> deckOfCards)
        {
            int n = deckOfCards.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                Card value = deckOfCards[k];
                deckOfCards[k] = deckOfCards[n];
                deckOfCards[n] = value;
            }
        }
        
        public Card DealCard()
        {
            
            return DeckOfCards[_currentCard++];   

        }
    }
}