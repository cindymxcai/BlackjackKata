using System.Collections.Generic;

namespace Blackjack
{
    public interface IDealer
    {
        Hand DealerHand { get; }
        void ShuffleCards(List<Card> deckOfCards);
        Card DealCard(List<Card> deckOfCards);
        void Hit(IDeck deck);
    }
}