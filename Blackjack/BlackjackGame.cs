using System;

namespace Blackjack
{
    public class BlackjackGame : IBlackjackGame
    {
        private readonly IPlayer _player;
        private readonly IDealer _dealer;
        public readonly IDeck Deck;
        public bool IsPlayingGame = true;
        public bool IsDealerTurn;
        public bool IsPlayerTurn = true;

        public BlackjackGame(IPlayer player, IDealer dealer, IDeck deck)
        {
            _player = player;
            _dealer = dealer;
            Deck = deck;
        }

        public void SetUpGame()
        {
            _dealer.ShuffleCards(Deck.DeckOfCards);
            _player.ReceiveCard(_dealer.DealCard(Deck.DeckOfCards));
            _player.ReceiveCard(_dealer.DealCard(Deck.DeckOfCards));
            _dealer.ReceiveCard(_dealer.DealCard(Deck.DeckOfCards));
            _dealer.ReceiveCard(_dealer.DealCard(Deck.DeckOfCards));
        }

        public void PlayGame()
        {
            SetUpGame();

            while (IsPlayingGame)
            {
                while (IsPlayerTurn)
                {
                    PlayPlayersTurn();
                }

                Console.WriteLine("______________________");
                while (IsDealerTurn)
                {
                    PlayDealersTurn();
                }

            }
            
            FindWinner();

        }

        public void PlayDealersTurn()
        {
            Display.DealerTurn(_dealer);
            try
            {
                _dealer.Hit(Deck);
            }
            catch (DealerOver17Exception dealerOver17Exception)
            {
                Console.WriteLine(dealerOver17Exception.Message);
                IsDealerTurn = false;
                IsPlayingGame = false;
            }
        }

        public void PlayPlayersTurn()
        {
            if (_player.HasBusted())
            {
                IsPlayerTurn = false;
                IsPlayingGame = false;
            }
            else if (_player.HasBlackJack())
            {
                IsPlayerTurn = false;
                IsDealerTurn = true;
            }
            else
            {
                Display.PlayerPrompt(_player);
                var response = _player.GetResponse();
                if (response == Response.Stay)
                {
                    IsPlayerTurn = false;
                    IsDealerTurn = true;
                }
                else
                {
                    PlayerHit();
                }
            }
        }

        private void FindWinner()
        {
            if (_player.HasBusted()) //if player busts -> dealer wins
            {
                Display.DealerWins();
            }
            else if (_dealer.HasBusted()) // if dealer busts -> player wins
            {
                Display.PlayerWin();
            }
            else if (_player.HasBlackJack() && _dealer.HasBlackJack()) //if both get blackjack -> draw
            {
                Display.Draw();
            }
            else //if neither gets blackjack or bust
            {
                if (_player.hand.CalculateScore() > _dealer.hand.CalculateScore()
                ) //if player is closer to 21 -> player wins
                {
                    Display.PlayerWin();
                }
                else if (_player.hand.CalculateScore() < _dealer.hand.CalculateScore()
                ) //if dealer is closer -> dealer wins
                {
                    Display.DealerWins();
                }
            }
        }

        private void PlayerHit()
        {
            var card = _dealer.DealCard(Deck.DeckOfCards);
            _player.ReceiveCard(card);
            Display.HitCard(card);
        }
    }
}