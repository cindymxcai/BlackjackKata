namespace BlackjackTest
{
    public class Card
    {        
        public string CardValue { get; }
        public string CardSuit { get; }

        public Card(string value, string suit)
        {
            CardValue = value;
            CardSuit = suit;
        }

        

    }
}