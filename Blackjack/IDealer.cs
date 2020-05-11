using System.Collections.Generic;

namespace Blackjack
{
    public interface IDealer 
    {
        void ShuffleCards(List<Card> deckOfCards);
        Card DealCard(List<Card> deckOfCards);
        void Hit(IDeck deck);
        Hand hand { get; }
        void ReceiveCard(Card dealtCard);
        bool HasBlackJack();
        bool HasBusted();
    }
}