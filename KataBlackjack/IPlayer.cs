namespace KataBlackjack
{
    public interface IPlayer
    {
        void Hit();
        void Stay();
        void CheckForBust(Hand playerHand);
        void CheckForWin();
    }
}