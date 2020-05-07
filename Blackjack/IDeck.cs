using System.Collections.Generic;

namespace Blackjack
{
    public interface IDeck
    {
        List<Card> DeckOfCards { get; }
    }
}