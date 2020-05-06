using System.Linq;
using Blackjack;
using Xunit;

namespace BlackjackTest
{
    public class DealerTest
    {
        [Fact]
        public void DealerShouldBeAbleToShuffleDeckOfCards()
        {
            var dealer = new Dealer();
            var deck = new Deck();
            var topCard = deck.DeckOfCards.First();
            dealer.ShuffleCards(deck.DeckOfCards);
            Assert.NotEqual(topCard, deck.DeckOfCards.First());
        }

        [Fact]
        public void DeckOfCardsIsCorrectAfterShuffling()
        {
            var dealer = new Dealer();
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
            var dealer = new Dealer();
            var deck = new Deck();
            dealer.DealCard(deck.DeckOfCards);
            Assert.Equal(51, deck.DeckOfCards.Count);
        }
    }
}