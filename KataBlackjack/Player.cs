using System;
using System.Collections.Generic;

namespace KataBlackjack
{
    public class Player : IPlayer
    {
        public bool prompt = true;
        public Player(Hand hand)
        {
            
        }
        public HitOrStay PromptMove()
        {
            Console.WriteLine("\nHit or Stay? (Hit = 1, Stay = 0)"); 
            var response = Console.ReadLine();

            while (true)
            {
                switch (response)
                {
                    case "1":
                        return HitOrStay.Hit;
                    case "0":
                        return HitOrStay.Stay;
                }
            }
            
        }
    }
}