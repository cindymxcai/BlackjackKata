using System;
using System.Collections.Generic;
using System.Linq;
using BlackjackTest;

namespace Blackjack
{
    public class Dealer
    {
        private static readonly Random Random = new Random();

        public void ShuffleCards(List<Card> deckOfCards)
        {
            var cardsInDeck = deckOfCards.Count;
            while (cardsInDeck > 0)
            {
                cardsInDeck--;
                var randomIndexedCard = Random.Next(0, deckOfCards.Count);
                var card = deckOfCards[randomIndexedCard];
                deckOfCards[randomIndexedCard] = deckOfCards[cardsInDeck];
                deckOfCards[cardsInDeck] = card;
            }
        }

        public Card DealCard(List<Card> deckOfCards)
        {
            var card = deckOfCards.First();
            deckOfCards.Remove(card);
            return card;

        }
    }
}