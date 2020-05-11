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
            Assert.Equal(2, player.hand.CardsInHand.Count);
            Assert.Equal(2, dealer.hand.CardsInHand.Count);
            Assert.Equal(48, blackjack.Deck.DeckOfCards.Count);
        }

        [Fact]
        public void DealerShouldDealCardIfPlayerHits()
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
            blackjack.PlayPlayersTurn();   
            Assert.Equal(1, player.hand.CardsInHand.Count);
        }
        
        [Fact]
        public void PlayerTurnEndsIfPlayerStays()
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
            blackjack.PlayPlayersTurn();   
            Assert.True(blackjack.IsDealerTurn);
            Assert.False(blackjack.IsPlayerTurn);
        }

        [Fact]
        public void IfPlayerBustsEndGame()
        {
            var cards = new List<Card>(){new Card("QUEENS", "CLUBS"), new Card("KINGS", "HEARTS")};
            var dealerHand = new Hand{CardsInHand = cards};
            var mock = new Mock<IConsoleReader>();
            mock.SetupSequence(reader => reader.GetInput()).Returns("1");
            var player = new Player(new Hand(), mock.Object);
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            IDealer dealer = new Dealer(dealerHand, mockRng.Object);
            var deck = new Deck();
            var blackjack = new BlackjackGame(player, dealer, deck);
            blackjack.PlayGame();
            Assert.True(player.HasBusted());
            Assert.False(blackjack.IsPlayingGame);
            Assert.False(blackjack.IsPlayerTurn);
        }
        
        [Fact]
        public void IfDealerBustsEndGame()
        {
            var cards = new List<Card>{new Card("QUEENS", "CLUBS"), new Card("KINGS", "HEARTS")};
            var playerHand = new Hand{CardsInHand = cards};
            var mock = new Mock<IConsoleReader>();
            mock.SetupSequence(reader => reader.GetInput()).Returns("1");
            var player = new Player(playerHand, mock.Object);
            var dealerHand = new Hand{CardsInHand = cards};
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            IDealer dealer = new Dealer(dealerHand, mockRng.Object);
            var deck = new Deck();
            var blackjack = new BlackjackGame(player, dealer, deck);
            blackjack.PlayDealersTurn();
            Assert.False(blackjack.IsPlayingGame);
        }
        
        
        [Fact]
        public void IfPlayerHasBlackjackPlayerTurnOver()
        {
            var deck = new Deck();
            var mockDealer = new Mock<IDealer>();
            var mockPlayer = new Mock<IPlayer>();
            mockPlayer.Setup(player => player.HasBlackJack()).Returns(true);
            mockPlayer.Setup(player => player.HasBusted()).Returns(false);
            
            var blackjack = new BlackjackGame(mockPlayer.Object, mockDealer.Object, deck);
            blackjack.PlayPlayersTurn();
            Assert.False(blackjack.IsPlayerTurn);
            Assert.True(blackjack.IsDealerTurn);
        }
    }
}