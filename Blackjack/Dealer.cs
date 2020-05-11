using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class Dealer : IDealer
    {
        private readonly IRng _rng;
        public Hand hand { get; }
        public Dealer(Hand _hand, IRng rng)
        {
            _rng = rng;
            hand = _hand;
        }

        public void ReceiveCard(Card dealtCard)
        {
            hand.CardsInHand.Add(dealtCard);
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
            if (hand.CalculateScore() < 17)
            {
                var dealtCard = DealCard(deck.DeckOfCards);
                ReceiveCard(dealtCard); 
                Display.DealerHitCard(dealtCard);
            }
            else
            {
                throw new DealerOver17Exception("Dealer is staying");
            }
        }

        public bool HasBlackJack()
        {
            if (!hand.HasBlackJack()) return false;
            //Display.Blackjack();
            Console.WriteLine("Dealer has blackjack!");
            return true;
        }

        public bool HasBusted()
        {
            if (!hand.HasBusted()) return false;
            //Display.Bust(this);
            Console.WriteLine("Dealer has busted!");
            return true;
        }
    }

    public class DealerOver17Exception : Exception
    {
        public DealerOver17Exception(string message) : base(message)
        {
        }
        
    }
}