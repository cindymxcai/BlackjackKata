using System;

namespace KataBlackjack
{
    public class Player : IPlayer
    {
        private bool playingTurn = true;
        public bool PlayerBust = false;
        public bool DealerBust = false;
        public void Hit()
        {
            
        }

        public void Stay()
        {
            
        }

        public void CheckForBust(Hand playerHand, Hand dealerHand)
        {
            if (playerHand.CalculateHandSum() > 21)
            {
                PlayerBust = true;
                Console.WriteLine("You have busted!");
                Console.WriteLine("With the hand" + playerHand);
            }
            else if(dealerHand.CalculateHandSum() > 21 )
            {
                DealerBust = true;
                Console.WriteLine("Dealer has busted!");
                Console.WriteLine("With the hand" + dealerHand);
            }
            else
            {
                DealerBust = false;
                PlayerBust = false;
            }
        }
        
        public void CheckForWinner

       
    }
}