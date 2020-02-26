using System;
using System.Collections.Generic;

namespace KataBlackjack
{
    public class Card : ICard
    {
        public  Value _Value { get; set; }
        public  Suit _Suit { get; set; }

        public Card(Value cardValue, Suit cardSuit)
        {
            this._Value = cardValue;
            this._Suit = cardSuit;
        }

        public enum Suit { Clubs, Diamonds, Hearts, Spades };

        public enum Value {
            Two , 
            Three, 
            Four , 
            Five , 
            Six , 
            Seven , 
            Eight , 
            Nine , 
            Ten , 
            Jack , 
            Queen , 
            King , 
            Ace 
        };
        
        //OVERRIDES TEST (allowing to test if same, but not same location)
        public override bool Equals(Object obj) 
        {
            if (obj is Card)
            {
                var that = obj as Card;

                return (this._Suit == that._Suit && this._Value == that._Value);
            }

            return false; 
        }
    }
    
}
