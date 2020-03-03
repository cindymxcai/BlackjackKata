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
        private static string _value;
        private static string _suit;


        [Fact]
        public void TestForBust()
        {
            List<Card> bust = new List<Card>
            {
                new Card(Card.Value.Eight, Card.Suit.Clubs), new Card(Card.Value.Seven, Card.Suit.Hearts),
                new Card(Card.Value.Jack, Card.Suit.Spades)
            };
            Hand bustHand = new Hand(bust);
            bustHand.CalculateHandSum();

            Game game = new Game();
            game.CheckForBust(bustHand, bustHand);

            Assert.Equal(25, 25);
            Assert.True(game.PlayerBust);
        }

        [Fact]
        public void TestForTie()
        {
            List<Card> playerCards = new List<Card>
                {new Card(Card.Value.Jack, Card.Suit.Clubs), new Card(Card.Value.Ace, Card.Suit.Hearts)};
            List<Card> dealerCards = new List<Card>
                {new Card(Card.Value.King, Card.Suit.Diamonds), new Card(Card.Value.Ace, Card.Suit.Spades)};

            Hand playerHand = new Hand(playerCards);
            Hand dealerHand = new Hand(dealerCards);
            playerHand.CalculateHandSum();
            dealerHand.CalculateHandSum();

            Game game = new Game();
            game.CheckForWinner(playerHand, dealerHand);
            Assert.True(game.Tied);
        }

        [Fact]
        public void PlayerWin()
        {
            List<Card> playerCards = new List<Card>
                {new Card(Card.Value.Jack, Card.Suit.Clubs), new Card(Card.Value.Nine, Card.Suit.Hearts)};
            List<Card> dealerCards = new List<Card>
                {new Card(Card.Value.Three, Card.Suit.Diamonds), new Card(Card.Value.Ace, Card.Suit.Spades)};

            Hand playerHand = new Hand(playerCards);
            Hand dealerHand = new Hand(dealerCards);
            playerHand.CalculateHandSum();
            dealerHand.CalculateHandSum();

            Game game = new Game();
            game.CheckForWinner(playerHand, dealerHand);
            Assert.True(game.PlayerWin);
        }

        [Fact]
        public void PlayerBlackjack()
        {
            List<Card> playerCards = new List<Card>
                {new Card(Card.Value.Jack, Card.Suit.Clubs), new Card(Card.Value.Ace, Card.Suit.Hearts)};
            List<Card> dealerCards = new List<Card>
                {new Card(Card.Value.Three, Card.Suit.Diamonds), new Card(Card.Value.Six, Card.Suit.Spades)};

            Hand playerHand = new Hand(playerCards);
            Hand dealerHand = new Hand(dealerCards);
            playerHand.CalculateHandSum();
            dealerHand.CalculateHandSum();

            Game game = new Game();
            game.CheckForWinner(playerHand, dealerHand);
            Assert.True(game.PlayerWin);
        }

        [Fact]
        public void DealerWin()
        {
            List<Card> playerCards = new List<Card>
                {new Card(Card.Value.Two, Card.Suit.Clubs), new Card(Card.Value.Five, Card.Suit.Hearts)};
            List<Card> dealerCards = new List<Card>
                {new Card(Card.Value.Ten, Card.Suit.Diamonds), new Card(Card.Value.Six, Card.Suit.Spades)};

            Hand playerHand = new Hand(playerCards);
            Hand dealerHand = new Hand(dealerCards);
            playerHand.CalculateHandSum();
            dealerHand.CalculateHandSum();

            Game game = new Game();
            game.CheckForWinner(playerHand, dealerHand);
            Assert.True(game.DealerWin);
        }

        [Fact]
        public void DealerBlackjack()
        {
            List<Card> playerCards = new List<Card>
                {new Card(Card.Value.Five, Card.Suit.Clubs), new Card(Card.Value.Ace, Card.Suit.Hearts)};
            List<Card> dealerCards = new List<Card>
            {
                new Card(Card.Value.Queen, Card.Suit.Diamonds), new Card(Card.Value.Six, Card.Suit.Spades),
                new Card(Card.Value.Five, Card.Suit.Hearts)
            };

            Hand playerHand = new Hand(playerCards);
            Hand dealerHand = new Hand(dealerCards);
            playerHand.CalculateHandSum();
            dealerHand.CalculateHandSum();

            Game game = new Game();
            game.CheckForWinner(playerHand, dealerHand);
            Assert.True(game.DealerWin);
        }

        [Fact]
        public void TestDealCardsRemovesFromDeck()
        {
            Deck deck = new Deck();
            Card card = new Card(Card.Value.Two, Card.Suit.Clubs);
            Card card2 = new Card(Card.Value.Five, Card.Suit.Diamonds);

            deck.DeckOfCards.Add(card2);
            deck.DeckOfCards.Add(card);

            Assert.Equal(2, deck.DeckOfCards.Count);
            deck.DealTopCard();
            Assert.Single(deck.DeckOfCards);
        }
    }
}