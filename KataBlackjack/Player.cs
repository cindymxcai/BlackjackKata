using System;

namespace KataBlackjack
{
    public class Player : IPlayer
    {
        private bool playingTurn = true;
        public bool PlayerBust = false;
        public bool DealerBust = false;
        public bool Tied = false;
        public bool PlayerWin = false;
        public bool DealerWin = false;
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

        public void CheckForWinner(Hand playerHand, Hand dealerHand)
        {
            if ((playerHand.CalculateHandSum() == 21) && dealerHand.CalculateHandSum() == 21)
            {
                Console.WriteLine("Tied!");
                Tied = true;
            }
            else if (playerHand.CalculateHandSum() == 21 || playerHand.CalculateHandSum() > dealerHand.CalculateHandSum() && playerHand.CalculateHandSum() < 22)
            {
                Console.WriteLine("You beat the dealer!");
                PlayerWin = true;
            }
            else if (dealerHand.CalculateHandSum() == 21 || dealerHand.CalculateHandSum() > playerHand.CalculateHandSum() && dealerHand.CalculateHandSum() < 22)
            {
                Console.WriteLine("Dealer Wins!");
                DealerWin = true;
            }
        }
    }
}