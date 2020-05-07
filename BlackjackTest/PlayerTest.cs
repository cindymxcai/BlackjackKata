using System.Collections.Generic;
using Blackjack;
using Moq;
using Xunit;

namespace BlackjackTest
{
    public class PlayerTest
    {
        [Fact]
        public void PlayerShouldHaveHand()
        {
            var hand = new Hand();
            var mock = new Mock<IConsoleReader>();
            mock.Setup(reader => reader.GetInput()).Returns("0");
            var player = new Player(hand, mock.Object);
            Assert.Equal(0, player.PlayerHand.CardsInHand.Count);
        }


        [Theory]
        [InlineData("1", Response.Hit)]
        [InlineData("0", Response.Stay)]
        
        public void PlayerShouldReturnHitOrStay(string input, Response response)
        {
            var mock = new Mock<IConsoleReader>();
            mock.Setup(reader => reader.GetInput()).Returns(input);
            var hand = new Hand();
            var player = new Player( hand, mock.Object );
            Assert.Equal(response, player.getResponse());
        }

        [Fact]
        public void PlayerShouldKeepGettingInputIfInvalid()
        {
            var hand = new Hand();
            var mock = new Mock<IConsoleReader>();
            mock.SetupSequence(reader => reader.GetInput()).Returns("10");
            var player = new Player( hand, mock.Object );
            Assert.Equal(Response.Invalid, player.getResponse());
        }

        [Fact]

        public void PlayerHasBlackJackIfHandEquals21()
        {
            var cards = new List<Card>{new Card("8", "DIAMONDS"), new Card("QUEEN", "HEARTS"), new Card("3", "CLUBS")};
            var mock = new Mock<IConsoleReader>();
            mock.SetupSequence(reader => reader.GetInput()).Returns("0");
            var hand = new Hand { CardsInHand =  cards};
            var player = new Player(hand, mock.Object);
            Assert.True(player.HasBlackJack(player));
        }

        [Fact]
        public void PlayerHasBustIfHandOver21()
        {
            var cards = new List<Card>{new Card("9", "DIAMONDS"), new Card("QUEEN", "HEARTS"), new Card("3", "CLUBS")};
            var mock = new Mock<IConsoleReader>();
            mock.SetupSequence(reader => reader.GetInput()).Returns("0");
            var hand = new Hand { CardsInHand =  cards};
            var player = new Player(hand, mock.Object);
            Assert.True(player.HasBusted(player));
        }
    }
}