using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class Dealer : IDealer
    {
        private readonly IRng _rng;
        public Hand DealerHand { get; }

        public Dealer(Hand hand, IRng rng)
        {
            _rng = rng;
            DealerHand = hand;
        }

        public void ShuffleCards(List<Card> deckOfCards)
        {
            var cardsInDeck = deckOfCards.Count;
            while (cardsInDeck > 0)
            {
                cardsInDeck--;
                var randomIndexedCard = _rng.Next(0, deckOfCards.Count);
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

        public void Hit(IDeck deck)
        {
            if (DealerHand.CalculateHandSum() < 17)
            {
                var card = DealCard(deck.DeckOfCards);
                DealerHand.CardsInHand.Add(card);
                Display.DealerHitCard(card);
            }
            else
            {
                throw new DealerOver17Exception("Dealer is staying");
            }
        }
    }

    public class DealerOver17Exception : Exception
    {
        public DealerOver17Exception(string message) : base(message)
        {
        }
    }
}