namespace KataBlackjack
{
    public interface IGame
    {
        bool CheckForBust(Hand playerHand, Hand dealerHand);
        bool CheckForWinner(Hand playerHand, Hand dealerHand);
    }
}