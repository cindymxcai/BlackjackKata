using System;
using System.Collections.Generic;

namespace KataBlackjack
{
    public class Player : IPlayer
    {
        public bool PlayerTurn = true;
        public bool DealerTurn = false;


        public void Play()
        {
    
            while (PlayerTurn)
            {
                Console.WriteLine("You are currently at "   );
                Console.WriteLine("with the hand "   );
                
                PlayerTurn = false;
            }
        }
        public void Hit()
        {
            
        }

        public void Stay()
        {
            
        }

        
    }
}