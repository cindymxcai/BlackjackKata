using System;
using System.Collections.Generic;
using System.Linq;
using KataBlackjack;
using Microsoft.VisualBasic;
using Xunit;


namespace TestBlackJack
{
    public class BlackjackTests
    {
        //Test total of multiple? eg add card 2 and king to hand. (12, getTotal)
        //hard vs soft hand with ace. eg if ace and jack, ace should be 11 with total of 21. 
        //if hand = 18, ace = 1
        
        private static string _value;
        private static string _suit;


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
            deck.Add();
            Assert.Equal(52, deck.DeckOfCards.Count);
            Assert.Equal(card, deck.DeckOfCards.First());
        }

        [Fact]
        public void TestDeckShuffle()
        {
            Deck deck = new Deck();
            deck.Add();
            Card card = new Card(Card.Value.Two, Card.Suit.Clubs);
            Assert.Equal(card, deck.DeckOfCards.First());
            deck.Shuffle<Card>(deck.DeckOfCards);
            Assert.NotEqual(card, deck.DeckOfCards.First());
        }

        [Fact]
        public void TestDeal()
        {
            Deck deck = new Deck();
            deck.Add();
            var firstCard = deck.DeckOfCards[0];
            var dealedCard = deck.DealCard();
            Assert.Equal(dealedCard, firstCard);
        }

        [Fact]
        public void TestCalculateHand()
        {
            List<Card> twoCards = new List<Card> { new Card(Card.Value.Two, Card.Suit.Clubs), new Card(Card.Value.Four, Card.Suit.Hearts) };
            Hand hand = new Hand(twoCards);
            hand.CalculateHandSum();
            Assert.Equal(6, hand.CalculateHandSum());
            
            List<Card> NonNumberCards = new List<Card> { new Card(Card.Value.Jack, Card.Suit.Clubs), new Card(Card.Value.Two, Card.Suit.Hearts)};
            Hand handFaceCards = new Hand(NonNumberCards);
            handFaceCards.CalculateHandSum();
            Assert.Equal(12, handFaceCards.CalculateHandSum());
        }

        [Fact]
        public void TestCalculateHandWithAces()
        {
            List<Card> aceAsOne = new List<Card> { new Card(Card.Value.Eight, Card.Suit.Clubs), new Card(Card.Value.Seven, Card.Suit.Hearts), new Card(Card.Value.Ace, Card.Suit.Spades)};
            Hand handOneAce = new Hand(aceAsOne);
            handOneAce.CalculateHandSum();
            Assert.Equal(16, handOneAce.CalculateHandSum());
            
            List<Card> aceAsEleven = new List<Card> { new Card(Card.Value.Three, Card.Suit.Clubs), new Card(Card.Value.Ace, Card.Suit.Spades)};
            Hand handElevenAce = new Hand(aceAsEleven);
            handElevenAce.CalculateHandSum();
            Assert.Equal(14, handElevenAce.CalculateHandSum());
        }

        [Fact]
        public void TestForBust()
        {
            List<Card> bust = new List<Card> { new Card(Card.Value.Eight, Card.Suit.Clubs), new Card(Card.Value.Seven, Card.Suit.Hearts), new Card(Card.Value.Jack, Card.Suit.Spades)};
            Hand bustHand = new Hand(bust);
            bustHand.CalculateHandSum();
            Player player = new Player();
            player.CheckForBust(bustHand);
            Assert.True(player.bust); 
        }
        
    }
}