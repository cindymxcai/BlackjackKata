using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KataBlackjack
{
    public class Hand : IHand
    {
        public List<Card> cardsInHand;

        public Hand(List<Card> cardsInHand)
        {
            this.cardsInHand = cardsInHand;
        }
        
       
        public int CalculateHandSum()
        {
            Deck deck = new Deck();
            deck.Shuffle(deck.DeckOfCards);

            int handSum = 0;
            cardsInHand.Add(deck.TakeTopCard());
            cardsInHand.Add(deck.TakeTopCard());
            
            foreach (var card in this.cardsInHand)
            {
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