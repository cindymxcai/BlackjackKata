namespace Blackjack
{
    public interface IRng
    {
        int Next(int minValue, int maxValue);
    }
}