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
        public bool playerTurn = true;
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
            while (playerTurn)
            {
                
                    Console.WriteLine("You are currently at " + playerHand.CalculateHandSum());
                    Console.Write("with the hand ");
                    playerHand.cardsInHand.ForEach(card => Console.Write( "[{0} of {1}], ", card._Value, card._Suit));
               
                    Player player = new Player(playerHand);
                    HitOrStay response = player.PromptMove();

                    if (response == HitOrStay.Hit)
                    {
                        playerHand.cardsInHand.Add(deck.DealTopCard());
                   
                    }

                    if (response == HitOrStay.Stay)
                    {
                        playerTurn = false;
                    }
                    
                    if (CheckForBust(playerHand, dealerHand))
                    {
                        playerTurn = false;
                    }
                    CheckForBlackjack(playerHand, dealerHand);
                    
                    if (PlayerWin)
                    {
                        playerTurn = false;
                    }


            }
        }
        
        public void DealTopCard(Hand hand)
        {
            hand.cardsInHand.Add(deck.DealTopCard());
        }

        public bool CheckForBust(Hand playerHand, Hand dealerHand)
        {
            if (playerHand.CalculateHandSum() > 21)
            {
                PlayerBust = true;
                Console.WriteLine("You have busted!");
                Console.WriteLine("With the hand ");
                playerHand.cardsInHand.ForEach(card => Console.Write( "[{0} of {1}], ", card._Value, card._Suit));
                Console.WriteLine();
                return true;
            }
            else if(dealerHand.CalculateHandSum() > 21 )
            {
                DealerBust = true;
                Console.WriteLine("Dealer has busted!");
                Console.WriteLine("With the hand" + dealerHand);
                return true;
            }
            else
            {
                return false;
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
                Console.Write("Dealer Wins! With the hand ");
                dealerHand.cardsInHand.ForEach(card => Console.Write( "[{0} of {1}], ", card._Value, card._Suit));
                DealerWin = true;
            }
        }

        public void CheckForBlackjack(Hand playerHand, Hand dealerHand)
        {
            if (playerHand.CalculateHandSum() == 21)
            {
                Console.WriteLine("You got Blackjack!");
                PlayerWin = true;
            }
            else if (dealerHand.CalculateHandSum() == 21 )
            {
                Console.Write("Dealer got Blackjack!");
                DealerWin = true;
            }
        }
    }
}