namespace Blackjack
{
    public interface IPlayer
    {
        Hand PlayerHand { get; }
        Response getResponse();
        bool HasBlackJack(IPlayer player);
        bool HasBusted(IPlayer player);
    }
}