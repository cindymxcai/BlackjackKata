using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class CardTest
    {
        [Theory]
        [InlineData("3", "SPADES")]
        [InlineData("5", "HEARTS")]
        [InlineData("QUEEN", "DIAMONDS")]
        [InlineData("ACE", "CLUBS")]
        [InlineData("9", "DIAMONDS")]
        [InlineData("2", "HEARTS")]
        [InlineData("JACK", "SPADES")]
        [InlineData("4", "CLUBS")]

        public void CardSetUpTest(string value, string suit)
        {
            var card = new Card(value, suit);
            Assert.Equal(suit,card.CardSuit);
            Assert.Equal(value, card.CardValue);
        }
    }
}