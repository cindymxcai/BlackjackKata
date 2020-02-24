using System;
using KataBlackjack;
using Xunit;

namespace TestBlackJack
{
    public class BlackjackTests
    {
        [Theory]
        [InlineData("Queen", "Hearts", 10)]
        public void card_taken_gives_correct_value(string value, string suit, int expected)
        {
            var card = new Card(value, suit);
            var actual = card.GetScore();
            Assert.Equal(expected, actual);
        }
    }
}