using System.Collections.Generic;

namespace KataBlackjack
{
    public interface IDeck
    {
        void AddCards();
        Card DealTopCard();
        void Shuffle<Card>( IList<Card> deckOfCards);
    }
}