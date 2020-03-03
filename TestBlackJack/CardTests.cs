using System.Linq;
using KataBlackjack;
using Xunit;

namespace TestBlackJack
{
    public class CardTests
    {
        [Fact]
        public void TestCardConstructor()
        {
            Card card1 = new Card(Card.Value.Queen, Card.Suit.Clubs);
            Card card2 = new Card(Card.Value.Five, Card.Suit.Hearts);

            Assert.NotEqual(Card.Suit.Diamonds, card1._Suit);
            Assert.Equal(Card.Suit.Clubs, card1._Suit);
            Assert.NotEqual(Card.Value.Eight, card1._Value);
            Assert.Equal(Card.Value.Queen, card1._Value);

            Assert.NotEqual(Card.Suit.Spades, card2._Suit);
            Assert.Equal(Card.Suit.Hearts, card2._Suit);
            Assert.NotEqual(Card.Value.Ace, card2._Value);
            Assert.Equal(Card.Value.Five, card2._Value);
        }

        [Fact]
        public void TestDeckConstructor()
        {
            Deck deck = new Deck();
            Card card = new Card(Card.Value.Two, Card.Suit.Clubs);
            deck.AddCards();
            Assert.Equal(52, deck.DeckOfCards.Count);
            Assert.Equal(card, deck.DeckOfCards.First());
        }

        [Fact]
        public void TestDeckShuffle()
        {
            Deck deck = new Deck();
            deck.AddCards();
            Card card = new Card(Card.Value.Two, Card.Suit.Clubs);
            Assert.Equal(card, deck.DeckOfCards.First());
            deck.Shuffle<Card>(deck.DeckOfCards);
            Assert.NotEqual(card, deck.DeckOfCards.First());
        }

        [Fact]
        public void TestTopCard()
        {
            Deck deck = new Deck();
            deck.AddCards();
            var firstCard = deck.DeckOfCards[0];
            var dealedCard = deck.DealTopCard();
            Assert.Equal(dealedCard, firstCard);
        }

        [Fact]
        public void TestDealTop()
        {
            Deck deck = new Deck();
            Card card = new Card(Card.Value.Two, Card.Suit.Clubs);
            deck.DeckOfCards.Add(card);
            Assert.Equal(card, deck.DealTopCard());

            deck.AddCards();
            deck.DealTopCard();
            Assert.Equal(51, deck.DeckOfCards.Count);
        }
    }
}