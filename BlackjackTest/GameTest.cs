using System.Collections.Generic;
using Blackjack;
using Moq;
using Xunit;

namespace BlackjackTest
{
    public class GameTest
    {
        [Fact]
        public void GameStartsByDealingTwoCardsToEachPlayer()
        {
            var playerHand = new Hand();
            var mock = new Mock<IConsoleReader>();
            mock.Setup(reader => reader.GetInput()).Returns("0");
            var player = new Player(playerHand, mock.Object);
            var dealerHand = new Hand();
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var dealer = new Dealer(dealerHand, mockRng.Object);
            var deck = new Deck();
            var blackjack = new BlackjackGame(player, dealer, deck);
            blackjack.SetUpGame();
            Assert.Equal(2, player.PlayerHand.CardsInHand.Count);
            Assert.Equal(2, dealer.DealerHand.CardsInHand.Count);
            Assert.Equal(48, blackjack.Deck.DeckOfCards.Count);
        }

        [Fact]
        public void IfPlayerHitsDealerDealsCard()
        {
            var playerHand = new Hand();
            var mock = new Mock<IConsoleReader>();
            mock.SetupSequence(reader => reader.GetInput()).Returns("1").Returns("0");
            var player = new Player(playerHand, mock.Object);
            var dealerHand = new Hand();
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var dealer = new Dealer(dealerHand, mockRng.Object);
            var deck = new Deck();
            var blackjack = new BlackjackGame(player, dealer, deck);
            blackjack.SetUpGame();
            blackjack.PlayGame();   
            Assert.Equal(3, player.PlayerHand.CardsInHand.Count);
        }

        [Fact]
        public void IfPlayerBustsEndGame()
        {
            var cards = new List<Card>{new Card("QUEENS", "DIAMONDS"), new Card("ACES", "HEARTS")};

            var playerHand = new Hand{CardsInHand = cards};
            var mock = new Mock<IConsoleReader>();
            mock.SetupSequence(reader => reader.GetInput()).Returns("1");
            var player = new Player(playerHand, mock.Object);
            var dealerHand = new Hand();
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var dealer = new Dealer(dealerHand, mockRng.Object);
            var deck = new Deck();
            var blackjack = new BlackjackGame(player, dealer, deck);
            blackjack.SetUpGame();
            blackjack.PlayGame();
            Assert.True(player.HasBusted(player));
            Assert.False(blackjack.IsPlayingGame);
            Assert.False(blackjack.IsPlayerTurn);
        }

        [Fact]
        public void IfPlayerBlackjackDealerTurn()
        {

            var playerHand = new Hand();
            var mock = new Mock<IConsoleReader>();
            mock.SetupSequence(reader => reader.GetInput()).Returns("0");
            var player = new Player(playerHand, mock.Object);
            var dealerHand = new Hand();
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var dealer = new Dealer(dealerHand, mockRng.Object);
            var deck = new Deck();
            var blackjack = new BlackjackGame(player, dealer, deck);
            var cards = new List<Card>{new Card("QUEENS", "DIAMONDS"), new Card("9", "HEARTS"), new Card("2", "CLUBS")};
            playerHand.CardsInHand = cards;
            blackjack.PlayGame();
            Assert.Equal(21, player.PlayerHand.CalculateHandSum());
            Assert.False(blackjack.IsPlayerTurn);
            Assert.True(player.HasBlackJack(player));
        }
    }
}