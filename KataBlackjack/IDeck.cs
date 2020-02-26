using System.Collections.Generic;

namespace KataBlackjack
{
    public interface IDeck
    {
        void Add();
        Card TakeTopCard();
        void Shuffle<Card>( IList<Card> deckOfCards);
        Card DealCard();
    }
}