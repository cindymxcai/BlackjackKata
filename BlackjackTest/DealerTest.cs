using System.Collections.Generic;
using System.Linq;
using Blackjack;
using Moq;
using Xunit;

namespace BlackjackTest
{
    public class DealerTest
    {
        [Fact]
        public void ShufflingCardsShouldPlaceCardsInDifferentPlaceInDeck()
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
            //Test original top card is no longer top card
            Assert.NotEqual(topCard, deck.DeckOfCards.First());
            topCard = deck.DeckOfCards.First();
            //test specific card value
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
            Assert.Equal(0,dealer.hand.CardsInHand.Count); 
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
        
        [Fact]
        public void DealerHasBlackJackIfHandEquals21()
        {
            var cards = new List<Card>{new Card("8", "DIAMONDS"), new Card("QUEEN", "HEARTS"), new Card("3", "CLUBS")};
            var mock = new Mock<IRng>();
            mock.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var hand = new Hand { CardsInHand =  cards};
            var dealer = new Dealer(hand, mock.Object);
            Assert.True(dealer.HasBlackJack());
            dealer.hand.CardsInHand.RemoveAll(card => true);
            Assert.False(dealer.HasBlackJack());
        }

        [Fact]
        public void DealerHasBustIfHandOver21()
        {
            var cards = new List<Card>{new Card("9", "DIAMONDS"), new Card("QUEEN", "HEARTS"), new Card("3", "CLUBS")};
            var mock = new Mock<IRng>();
            mock.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var hand = new Hand { CardsInHand =  cards};
            var dealer = new Dealer(hand, mock.Object);
            Assert.True(dealer.HasBusted());
            dealer.hand.CardsInHand.RemoveAll(card => true);
            Assert.False(dealer.HasBusted());
        }

        [Fact]
        public void DealerHitsIfScoreUnder17()
        {
            var cards = new List<Card>{new Card("9", "DIAMONDS"), new Card("3", "CLUBS")};
            var mock = new Mock<IRng>();
            mock.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var hand = new Hand { CardsInHand =  cards};
            var dealer = new Dealer(hand, mock.Object);
            var deck = new Deck();
            dealer.Hit(deck);
            Assert.Equal(3, dealer.hand.CardsInHand.Count);
        }

        [Fact]

        public void DealerShouldThrowExceptionIfOver17()
        {
            var cards = new List<Card>{new Card("9", "DIAMONDS"), new Card("QUEENS", "CLUBS")};
            var mock = new Mock<IRng>();
            mock.Setup(rng => rng.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            var hand = new Hand { CardsInHand =  cards};
            var dealer = new Dealer(hand, mock.Object);
            var deck = new Deck();
            Assert.Throws<DealerOver17Exception>(()=>dealer.Hit(deck));
        }

    }
}