using System;
using System.Collections.Generic;

namespace KataBlackjack
{
    public class Hand : IHand
    {
        private readonly List<Card> _cardsInHand;

        public Hand(List<Card> cardsInHand)
        {
            this._cardsInHand = cardsInHand;
        }
        
        public int CalculateHandSum()
        {
            int handSum = 0;

            foreach (var card in this._cardsInHand)
            {
                int number;
                if ((int)card._Value < (int)Card.Value.Ten)
                {
                    handSum += (int)card._Value;
                }  
                
                else if (card._Value != Card.Value.Ace)
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