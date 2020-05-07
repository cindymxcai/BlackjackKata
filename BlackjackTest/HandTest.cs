using System.Collections.Generic;
using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class HandTest
    {
        [Fact]
        public void HandShouldBeEmptyInitially()
        {
            var hand = new Hand();
            Assert.Equal(0, hand.CardsInHand.Count);
        }

        [Fact]
        public void HandShouldCalculateSumOfCards()
        {
            var twoCards = new List<Card> {new Card("3", "SPADES"), new Card("5", "HEARTS")};
            var hand = new Hand {CardsInHand = twoCards};
            Assert.Equal(8, hand.CalculateHandSum());
        }

        [Fact]
        public void HandShouldCalculateHandSumWithFaceCards()
        {
            var cards = new List<Card>{new Card("KING", "DIAMONDS"), new Card("2", "HEARTS"), new Card("5", "CLUBS")};
            var hand = new Hand {CardsInHand = cards};
            Assert.Equal(17, hand.CalculateHandSum());
            
        }

        [Fact]
        public void HandShouldAddAceAs11IfSumIsUnder21()
        {
            var cards = new List<Card>{new Card("3", "DIAMONDS"), new Card("2", "HEARTS"), new Card("ACE", "CLUBS")};
            var hand = new Hand {CardsInHand = cards};
            Assert.Equal(16, hand.CalculateHandSum());
        }

        [Fact]
        public void HandShouldAddAceAs1IfSumIsOver21()
        {            
            var cards = new List<Card>{new Card("3", "DIAMONDS"), new Card("2", "HEARTS"), new Card("9", "CLUBS")};
            var hand = new Hand { CardsInHand =  cards};
            hand.CardsInHand.Add(new Card("ACE", "CLUBS"));
            var sum =  hand.CalculateHandSum();
            Assert.Equal(15, sum);
        }
    }
}