namespace Blackjack
{
    public interface IPlayer
    {
        Hand hand { get; }
        void ReceiveCard(Card dealtCard);
        bool HasBlackJack();
        bool HasBusted();
        Response GetResponse();
    }
}