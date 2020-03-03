using System;

namespace KataBlackjack
{
    public class Game : IGame
    {
        public bool IsPlayerBust = false;
        public bool IsDealerBust = false;
        public bool IsTied = false;
        public bool IsPlayerWin = false;
        public bool IsDealerWin = false;
        public bool IsPlayerTurn = true;
        public bool IsDealerTurn = false;
        Deck deck = new Deck();


        public void SetUpGame(Hand playerHand, Hand dealerHand)
        {
            deck.AddCards();
            deck.Shuffle(deck.DeckOfCards);
            playerHand.cardsInHand.Add(deck.DealTopCard());
            playerHand.cardsInHand.Add(deck.DealTopCard());

            dealerHand.cardsInHand.Add(deck.DealTopCard());
            dealerHand.cardsInHand.Add(deck.DealTopCard());
        }


        public void Gameloop(Hand playerHand, Hand dealerHand)
        {
            while (IsPlayerTurn)
            {
                Console.WriteLine("You are currently at " + playerHand.CalculateHandSum());
                Console.Write("with the hand ");

                playerHand.cardsInHand.ForEach(card => Console.Write("[{0} of {1}], ", card._Value, card._Suit));

                Console.ResetColor();
                Player player = new Player(playerHand);
                HitOrStay response = player.PromptMove();

                if (response == HitOrStay.Hit)
                {
                    playerHand.cardsInHand.Add(deck.DealTopCard());
                    if (IsBust(playerHand, dealerHand))
                    {
                        IsPlayerTurn = false;
                    }

                    CheckForBlackjack(playerHand, dealerHand);

                    if (IsPlayerWin)
                    {
                        IsPlayerTurn = false;
                    }
                }

                if (response == HitOrStay.Stay)
                {
                    IsPlayerTurn = false;
                    IsDealerTurn = true;
                    Console.WriteLine("____________________________________________________________");
                }
            }

            while (IsDealerTurn)
            {
                Console.WriteLine("Dealer is currently at " + dealerHand.CalculateHandSum());
                Console.Write("with the hand ");
                dealerHand.cardsInHand.ForEach(card => Console.Write("[{0} of {1}], ", card._Value, card._Suit));
                Console.WriteLine();
                Player player = new Player(dealerHand);

                if (dealerHand.CalculateHandSum() > playerHand.CalculateHandSum())
                {
                    Console.WriteLine("Dealer wins!");
                    IsPlayerTurn = false;
                    IsDealerTurn = false;
                }
                else if (dealerHand.CalculateHandSum() < 17)
                {
                    Console.WriteLine("\nDealer Hit!");
                    dealerHand.cardsInHand.Add(deck.DealTopCard());
                    IsDealerTurn = true;
                    IsBust(playerHand, dealerHand);
                }
                else
                {
                    HitOrStay response = player.PromptMove();
                    if (response == HitOrStay.Hit)
                    {
                        dealerHand.cardsInHand.Add(deck.DealTopCard());
                        if (IsBust(playerHand, dealerHand))
                        {
                            IsDealerTurn = false;
                        }

                        CheckForBlackjack(playerHand, dealerHand);

                        if (IsDealerWin)
                        {
                            IsDealerTurn = false;
                        }
                    }

                    if (response == HitOrStay.Stay)
                    {
                        IsPlayerTurn = false;
                        IsDealerTurn = false;
                        CheckForWinner(playerHand, dealerHand);
                    }
                }
            }
        }

        public void DealTopCard(Hand hand)
        {
            hand.cardsInHand.Add(deck.DealTopCard());
        }

        public bool IsBust(Hand playerHand, Hand dealerHand)
        {
            if (playerHand.CalculateHandSum() > 21)
            {
                IsPlayerBust = true;
                Console.WriteLine("You have busted! You are at " + playerHand.CalculateHandSum());
                Console.WriteLine("With the hand ");
                playerHand.cardsInHand.ForEach(card => Console.Write("[{0} of {1}], ", card._Value, card._Suit));
                Console.WriteLine();
                return true;
            }
            else if (dealerHand.CalculateHandSum() > 21)
            {
                IsDealerBust = true;
                Console.WriteLine("Dealer has busted!");
                Console.WriteLine("With the hand");
                dealerHand.cardsInHand.ForEach(card => Console.Write("[{0} of {1}], ", card._Value, card._Suit));
                Console.WriteLine("\nYou beat the dealer!");
                IsDealerTurn = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckForWinner(Hand playerHand, Hand dealerHand)
        {
            if (playerHand.CalculateHandSum() == dealerHand.CalculateHandSum())
            {
                Console.WriteLine("Tied!");
                return true;
            }
            else if (playerHand.CalculateHandSum() > dealerHand.CalculateHandSum() &&
                     playerHand.CalculateHandSum() < 22)
            {
                Console.WriteLine("You beat the dealer!");
                return true;
            }
            else if (dealerHand.CalculateHandSum() > playerHand.CalculateHandSum() &&
                     dealerHand.CalculateHandSum() < 22)
            {
                Console.Write("Dealer Wins! With the hand ");
                dealerHand.cardsInHand.ForEach(card => Console.Write("[{0} of {1}], ", card._Value, card._Suit));
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckForBlackjack(Hand playerHand, Hand dealerHand)
        {
            if (playerHand.CalculateHandSum() == 21)
            {
                Console.WriteLine("You got Blackjack!");
            }
        }
    }
}