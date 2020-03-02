namespace KataBlackjack
{
    public interface IGame
    {
        bool CheckForBust(Hand playerHand, Hand dealerHand);
        void CheckForWinner(Hand playerHand, Hand dealerHand);
    }
}