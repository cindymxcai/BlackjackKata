using System.Collections.Generic;
using KataBlackjack;
using Xunit;

namespace TestBlackJack
{
    public class HandTests
    {

        [Fact]
        public void TestCalculateHand()
        {
            List<Card> twoCards = new List<Card> { new Card(Card.Value.Two, Card.Suit.Clubs), new Card(Card.Value.Four, Card.Suit.Hearts) };
            Hand hand = new Hand(twoCards);
            Assert.Equal(6, hand.CalculateHandSum());
            
            List<Card> nonNumberCards = new List<Card> { new Card(Card.Value.Jack, Card.Suit.Clubs), new Card(Card.Value.Two, Card.Suit.Hearts)};
            Hand handFaceCards = new Hand(nonNumberCards);
            Assert.Equal(12, handFaceCards.CalculateHandSum());
        }

        [Fact]
        public void TestCalculateHandWithAces()
        {
            List<Card> aceAsOne = new List<Card> { new Card(Card.Value.Eight, Card.Suit.Clubs), new Card(Card.Value.Seven, Card.Suit.Hearts), new Card(Card.Value.Ace, Card.Suit.Spades)};
            Hand handOneAce = new Hand(aceAsOne);
            Assert.Equal(16, handOneAce.CalculateHandSum());
            
            List<Card> aceAsEleven = new List<Card> { new Card(Card.Value.Three, Card.Suit.Clubs), new Card(Card.Value.Ace, Card.Suit.Spades)};
            Hand handElevenAce = new Hand(aceAsEleven);
            Assert.Equal(14, handElevenAce.CalculateHandSum());
        }
    }
}