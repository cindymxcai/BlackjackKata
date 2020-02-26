namespace KataBlackjack
{
    public class Dealer : IPlayer
    {
        private bool playingTurn = false;
        
        //must keep hitting until reached 17. 
        //then if reached 17, can stay
        public void Hit()
        {
            throw new System.NotImplementedException();
        }

        public void Stay()
        {
            throw new System.NotImplementedException();
        }

        public void CheckForBust(Hand playerHand)
        {
            throw new System.NotImplementedException();
        }

        public void CheckForWin()
        {
            throw new System.NotImplementedException();
        }
    }
}