using System;

namespace KataBlackjack
{
    public interface ICard
    {
        Card.Value _Value { get; set; }
        Card.Suit _Suit { get; set; }
        bool Equals(Object obj);
    }
}