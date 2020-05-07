namespace Blackjack
{
    public interface IPlayer
    {
        Hand PlayerHand { get; }
        Response GetResponse();
        bool HasBlackJack(IPlayer player);
        bool HasBusted(IPlayer player);
    }
}