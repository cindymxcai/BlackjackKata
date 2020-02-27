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
        private Card dealtCard; 
       

        public void Add()
        {
            foreach (Card.Suit s in Enum.GetValues((typeof(Card.Suit))))
            {
              //  Console.WriteLine("______________");
                foreach (Card.Value v in Enum.GetValues(typeof(Card.Value)))
                {
                    DeckOfCards.Add(new Card(v,s));
                   // Console.WriteLine("Suit:" + s + "    Value:" + v);
                }
            }
        }
        
        public Card TakeTopCard()
        {
            Card card = DeckOfCards.First();
            DeckOfCards.Remove(card);
            return card;        
            }

        public void Shuffle<Card>( IList<Card> deckOfCards)
        {
            int cardsInDeck = deckOfCards.Count;
            while (cardsInDeck > 1)
            {
                cardsInDeck--;
                int randomNumber = Random.Next(cardsInDeck + 1);
                Card value = deckOfCards[randomNumber];
                deckOfCards[randomNumber] = deckOfCards[cardsInDeck];
                deckOfCards[cardsInDeck] = value;
            }
        }
        
    }
}