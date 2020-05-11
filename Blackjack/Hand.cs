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

        public int CalculateScore()
        {
            var score = 0;
            foreach (var card in CardsInHand)
            {
                if (int.TryParse(card.CardValue, out _))
                {
                    score += int.Parse(card.CardValue);
                }
                else
                {
                    if (card.CardValue != "ACE")
                    {
                        score += 10;
                    }
                    else if (score <= 10)
                    {
                        score += 11;
                    }
                    else
                    {
                        score += 1;
                    }
                }
            }

            return score;
        }
        
        public bool HasBlackJack()
        {
            return CalculateScore() == 21;
        }

        public bool HasBusted()
        {
            return CalculateScore() > 21;
        }
    }
}