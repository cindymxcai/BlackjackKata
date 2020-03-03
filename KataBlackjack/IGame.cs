namespace KataBlackjack
{
    public interface IGame
    {
        bool IsBust(Hand playerHand, Hand dealerHand);
        bool CheckForWinner(Hand playerHand, Hand dealerHand);
    }
}