using System.Collections.Generic;

namespace Blackjack
{
    public class Hand
    {
        public List<Card> CardsInHand { get; set; }

        public Hand()
        {
            CardsInHand = new List<Card>();
        }

        public int CalculateHandSum()
        {
            var handSum = 0;
            foreach (var card in CardsInHand)
            {
                if (int.TryParse(card.CardValue, out _))
                {
                    handSum += int.Parse(card.CardValue);
                }
                else
                {
                    if (card.CardValue != "ACE")
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
            }

            return handSum;
        }
    }
}