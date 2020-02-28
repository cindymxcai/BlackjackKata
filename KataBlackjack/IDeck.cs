using System.Collections.Generic;

namespace KataBlackjack
{
    public interface IDeck
    {
        void Add();
        Card DealTopCard();
        void Shuffle<Card>( IList<Card> deckOfCards);
    }
}