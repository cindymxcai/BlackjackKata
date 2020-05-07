using System.Linq;
using Blackjack;
using Moq;
using Xunit;

namespace BlackjackTest
{
    public class DealerTest
    {
        [Fact]
        public void DealerShouldBeAbleToShuffleDeckOfCards()
        {
            var hand = new Hand();
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            var dealer = new Dealer(hand, mockRng.Object);
            var deck = new Deck();
            var topCard = deck.DeckOfCards.First();
            dealer.ShuffleCards(deck.DeckOfCards);
            Assert.NotEqual(topCard, deck.DeckOfCards.First());
        }

        [Fact]
        public void DealingCardsShouldPlaceCardsInDifferentPlaceInDeck()
        {
            var hand = new Hand();
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            var dealer = new Dealer(hand, mockRng.Object);
            var deck = new Deck();
            var topCard = deck.DeckOfCards.First();
            Assert.Equal("ACE", topCard.CardValue);
            Assert.Equal("SPADES", topCard.CardSuit);
            dealer.ShuffleCards(deck.DeckOfCards);
            topCard = deck.DeckOfCards.First();
            Assert.Equal("2", topCard.CardValue );
            Assert.Equal("SPADES", topCard.CardSuit );

        }

        [Fact]
        public void DeckOfCardsIsCorrectAfterShuffling()
        {
            var hand = new Hand();
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            var dealer = new Dealer(hand, mockRng.Object);
            var deck = new Deck();
            dealer.ShuffleCards(deck.DeckOfCards);
            Assert.Equal(13, deck.DeckOfCards.Count(card => card.CardSuit == "SPADES"));
            Assert.Equal(13, deck.DeckOfCards.Count(card => card.CardSuit == "HEARTS"));
            Assert.Equal(13, deck.DeckOfCards.Count(card => card.CardSuit == "CLUBS"));
            Assert.Equal(13, deck.DeckOfCards.Count(card => card.CardSuit == "DIAMONDS"));
        }
        
        [Fact]
        public void DealerShouldDealCards()
        {
            var hand = new Hand();
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            var dealer = new Dealer(hand, mockRng.Object);
            var deck = new Deck();
            dealer.DealCard(deck.DeckOfCards);
            Assert.Equal(51, deck.DeckOfCards.Count);
        }

        [Fact]
        public void DealerShouldHaveHand()
        {
            var hand = new Hand();
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var dealer = new Dealer(hand, mockRng.Object);
            Assert.Equal(0,dealer.DealerHand.CardsInHand.Count); 
        }

        [Fact]
        public void DealerShouldDealTopCard()
        {
            var hand = new Hand();
            var mockRng = new Mock<IRng>();
            mockRng.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var dealer = new Dealer(hand, mockRng.Object);
            var deck = new Deck();
            dealer.ShuffleCards(deck.DeckOfCards);
            var dealtCard = dealer.DealCard(deck.DeckOfCards);
            Assert.Equal("SPADES",dealtCard.CardSuit); 
            Assert.Equal("3",dealtCard.CardValue);
        }

    }
}