namespace KataBlackjack
{
    public interface IGame
    {
        void CheckForBust(Hand playerHand, Hand dealerHand);
        void CheckForWinner(Hand playerHand, Hand dealerHand);
    }
}