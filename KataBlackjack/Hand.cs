using System;
using System.Collections.Generic;

namespace KataBlackjack
{
    public class Hand
    {
        
        public List<Card> cardsInHand = new List<Card>();

        public Hand(List<Card> cardsInHand)
        {
            this.cardsInHand = cardsInHand;
        }
        
        public int CalculateHandSum()
        {
            int handSum = 0;

            foreach (var card in this.cardsInHand)
            {
                int number;
                if ((int)card._Value < 12)
                {
                    handSum += (int)card._Value;
                }  
                
                else if (card._Value.ToString() != "Ace")
                {
                    handSum += 10;
                }
                else if (handSum <= 10)
                {
                    handSum += 11;
                }
                else
                {
                    handSum += 1;
                }
            }

            return handSum;
        }
    }
}