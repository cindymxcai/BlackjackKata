using System;

namespace KataBlackjack
{
    public class Game : IGame
    {
        
        public bool PlayerBust = false;
        public bool DealerBust = false;
        public bool Tied = false;
        public bool PlayerWin = false;
        public bool DealerWin = false;
        private bool _playerTurn = true;
        private bool _dealerTurn = false;
        readonly Deck _deck = new Deck();


        public void DealCards(Hand playerHand, Hand dealerHand)
        {
            playerHand.cardsInHand.Add(_deck.DealTopCard());
            playerHand.cardsInHand.Add(_deck.DealTopCard());

            dealerHand.cardsInHand.Add(_deck.DealTopCard());
            dealerHand.cardsInHand.Add(_deck.DealTopCard());
        }
        
        public void Play(Hand playerHand, Hand dealerHand)
        {

            while (_playerTurn)
            {
                Console.WriteLine("You are currently at " + playerHand.CalculateHandSum());
                Console.WriteLine("with the hand " + playerHand);

                Console.WriteLine("Hit or Stay? (Hit = 1, Stay = 0)");
                var hitOrStay = Console.ReadLine();
                
                CheckForBust(playerHand,dealerHand);
                CheckForWinner(playerHand, dealerHand);

                if (hitOrStay == "1")
                {
                    _playerTurn = true;
                }
                else if (hitOrStay == "0")
                {
                    _playerTurn = false;
                    _dealerTurn = true;
                }
                else
                {
                    Console.WriteLine("invalid input! Try again");
                    hitOrStay = Console.ReadLine();
                }
            }


            while (_dealerTurn)
            {
                Console.WriteLine("Dealer is currently at " + dealerHand.CalculateHandSum());
                Console.WriteLine("with the hand " + dealerHand);

                if (dealerHand.CalculateHandSum() < 17)
                {
                    var card = _deck.DealTopCard();
                    Console.WriteLine("Dealer Hit with " + card);
                    dealerHand.cardsInHand.Add(card);
                    CheckForBust(playerHand,dealerHand);
                    CheckForWinner(playerHand, dealerHand);
                }
                
            }
        }
        
        
        public void CheckForBust(Hand playerHand, Hand dealerHand)
        {
            if (playerHand.CalculateHandSum() > 21)
            {
                PlayerBust = true;
                Console.WriteLine("You have busted!");
                Console.WriteLine("With the hand" + playerHand);
            }
            else if(dealerHand.CalculateHandSum() > 21 )
            {
                DealerBust = true;
                Console.WriteLine("Dealer has busted!");
                Console.WriteLine("With the hand" + dealerHand);
            }
            else
            {
                DealerBust = false;
                PlayerBust = false;
            }
        }

        public void CheckForWinner(Hand playerHand, Hand dealerHand)
        {
            if ((playerHand.CalculateHandSum() == 21) && dealerHand.CalculateHandSum() == 21)
            {
                Console.WriteLine("Tied!");
                Tied = true;
            }
            else if (playerHand.CalculateHandSum() == 21 || playerHand.CalculateHandSum() > dealerHand.CalculateHandSum() && playerHand.CalculateHandSum() < 22)
            {
                Console.WriteLine("You beat the dealer!");
                PlayerWin = true;
            }
            else if (dealerHand.CalculateHandSum() == 21 || dealerHand.CalculateHandSum() > playerHand.CalculateHandSum() && dealerHand.CalculateHandSum() < 22)
            {
                Console.WriteLine("Dealer Wins!");
                DealerWin = true;
            }
        }
    }
}