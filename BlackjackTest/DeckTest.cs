using System.Linq;
using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class DeckTest
    {
        [Fact]
        public void DeckShouldHave52Cards()
        {
            var deck = new Deck();
            Assert.Equal(52, deck.DeckOfCards.Count);
        }

        [Fact]
        public void DeckShouldHaveAllCardSuits()
        {
            var deck = new Deck();
            Assert.Equal(13, deck.DeckOfCards.Count(card => card.CardSuit == "SPADES"));
            Assert.Equal(13, deck.DeckOfCards.Count(card => card.CardSuit == "HEARTS"));
            Assert.Equal(13, deck.DeckOfCards.Count(card => card.CardSuit == "CLUBS"));
            Assert.Equal(13, deck.DeckOfCards.Count(card => card.CardSuit == "DIAMONDS"));
        }

        [Theory]
        [InlineData("ACE")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("6")]
        [InlineData("7")]
        [InlineData("8")]
        [InlineData("9")]
        [InlineData("10")]
        [InlineData("JACK")]
        [InlineData("QUEEN")]
        [InlineData("KING")]
        public void DeckShouldHaveAllCardValues(string value)
        {
            var deck = new Deck();
            Assert.Equal(4, deck.DeckOfCards.Count(card => card.CardValue == value));
        }

        
    }
}