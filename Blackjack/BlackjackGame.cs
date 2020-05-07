using System;
using System.Linq;

namespace Blackjack
{
    public class BlackjackGame : IBlackjackGame
    {
        private readonly IPlayer _player;
        private readonly IDealer _dealer;
        public readonly IDeck Deck;
        public bool _isPlayingGame = true;
        public bool _isDealerTurn;
        public bool _isPlayerTurn = true;

        public BlackjackGame(IPlayer player, IDealer dealer, IDeck deck)
        {
            _player = player;
            _dealer = dealer;
            Deck = deck;
        }
        public void SetUpGame()
        {
            _dealer.ShuffleCards(Deck.DeckOfCards);
           _player.PlayerHand.CardsInHand.Add(_dealer.DealCard(Deck.DeckOfCards));
           _player.PlayerHand.CardsInHand.Add(_dealer.DealCard(Deck.DeckOfCards));
           _dealer.DealerHand.CardsInHand.Add(_dealer.DealCard(Deck.DeckOfCards));
           _dealer.DealerHand.CardsInHand.Add(_dealer.DealCard(Deck.DeckOfCards));
        }

        public void PlayGame()
        {

            while (_isPlayingGame)
            {
                while (_isPlayerTurn )
                {
                    if (_player.HasBusted(_player))
                    {
                        _isPlayerTurn = false;
                        _isPlayingGame = false;
                    }

                    else if (_player.HasBlackJack(_player))
                    {
                        _isPlayerTurn = false;
                        _isDealerTurn = true;
                    }
                    else
                    {
                        
                        Display.PlayerPrompt(_player);

                        var response = _player.getResponse();


                        if (response == Response.Stay)
                        {
                            _isPlayerTurn = false;
                            _isDealerTurn = true;
                        }
                        else
                        {
                            PlayerHit();
                        }
                    }
                }
                Console.WriteLine("______________________");
                while (_isDealerTurn)
                {
                    Display.DealerTurn(_dealer);

                    try
                    {
                        _dealer.Hit(Deck);
                    }
                    catch (DealerOver17Exception dealerOver17Exception)
                    {
                        Console.WriteLine(dealerOver17Exception.Message);
                        _isDealerTurn = false;
                        _isPlayingGame = false;
                    }

                } 


                FindWinner();
            }
        }

        private void FindWinner()
        {
            if (_player.HasBusted(_player)) //if player busts -> dealer wins
            {
                Display.DealerWins();
            }
            else if (_dealer.DealerHand.CalculateHandSum() > 21) // if dealer busts -> player wins
            {
                Display.PlayerWin();
            }
            else if( _player.HasBlackJack(_player) && _dealer.DealerHand.CalculateHandSum() == 21) //if both get blackjack -> draw
            {
                Display.Draw();
            }
            else//if neither gets blackjack or bust
            {
                if (_player.PlayerHand.CalculateHandSum() > _dealer.DealerHand.CalculateHandSum() && _dealer.DealerHand.CalculateHandSum() <= 21 ) //if player is closer to 21 -> player wins
                {
                    Display.PlayerWin();
                }
                else if (_player.PlayerHand.CalculateHandSum() < _dealer.DealerHand.CalculateHandSum() && _dealer.DealerHand.CalculateHandSum() <= 21) //if dealer is closer -> dealer wins
                {
                    Display.DealerWins();
                }
            }
            
        }
        private void PlayerHit()
        {
            var card = _dealer.DealCard(Deck.DeckOfCards);
            _player.PlayerHand.CardsInHand.Add(card);
            Display.PlayerHitCard(card);
        }
    }
}