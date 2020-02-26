using System;

namespace KataBlackjack
{
    public class Player : IPlayer
    {
        private bool playingTurn = true;
        public bool bust = false;
        public void Hit()
        {
            
        }

        public void Stay()
        {
            
        }

        public void CheckForBust(Hand playerHand)
        {
            if (playerHand.CalculateHandSum() > 21)
            {
                bust = true;
                Console.WriteLine("You have busted!");
                Console.WriteLine("With the hand" + playerHand);
            }
        }

        public void CheckForWin()
        {
            
        }
    }
}