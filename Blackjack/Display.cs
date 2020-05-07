using System;

namespace Blackjack
{
    public static class Display
    {
        public static void PlayerPrompt(IPlayer player)
        {
            Console.Write($"You are at currently at {player.PlayerHand.CalculateHandSum()}\n with the hand [");
            foreach (var card in player.PlayerHand.CardsInHand)
            {
                if (card.CardSuit == "HEARTS" || card.CardSuit == "DIAMONDS")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[{card.CardValue} , {card.CardSuit} ]");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"[{card.CardValue} , {card.CardSuit} ]");
                }

            }
            Console.WriteLine("]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Hit or stay? (Hit = 1, Stay = 0)");
            Console.ResetColor();
        }

        public static void DealerTurn(IDealer dealer)
        {
            Console.Write($"Dealer is currently at {dealer.DealerHand.CalculateHandSum()}\n with the hand [");
            foreach (var card in dealer.DealerHand.CardsInHand)
            {
                if (card.CardSuit == "HEARTS" || card.CardSuit == "DIAMONDS")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[{card.CardValue} , {card.CardSuit} ]");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"[{card.CardValue} , {card.CardSuit} ]");
                }

            }
            Console.WriteLine("]");
        }
        public static void PlayerHitCard(Card card)
        {
            Console.WriteLine($"You draw [{card.CardValue} , {card.CardSuit}]");
        }
        
        public static void DealerHitCard(Card card)
        {
            Console.WriteLine($"You draw [{card.CardValue} , {card.CardSuit}]");
        }

        public static void Blackjack(IPlayer player)
        {
            Console.Write("Player has Blackjack! With hand");
            foreach (var card in player.PlayerHand.CardsInHand)
            {
                if (card.CardSuit == "HEARTS" || card.CardSuit == "DIAMONDS")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[{card.CardValue} , {card.CardSuit} ]");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"[{card.CardValue} , {card.CardSuit} ]");
                }

            }
            Console.WriteLine("]");
        }

        public static void Bust(IPlayer player)
        {
            Console.WriteLine("Player has Busted! With hand");
            foreach (var card in player.PlayerHand.CardsInHand)
            {
                if (card.CardSuit == "HEARTS" || card.CardSuit == "DIAMONDS")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"[{card.CardValue} , {card.CardSuit} ]");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"[{card.CardValue} , {card.CardSuit} ]");
                }

            }
            Console.WriteLine("]");
        }

        public static void PlayerWin()
        {
            Console.WriteLine("Player WON!");
            
        }

        public static void DealerWins()
        {
            Console.WriteLine("Dealer WON");
        }

        public static void Draw()
        {
            Console.WriteLine("DRAW");
        }
    }
}