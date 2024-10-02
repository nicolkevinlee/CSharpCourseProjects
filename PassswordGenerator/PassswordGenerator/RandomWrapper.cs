//the class to be refactored as an assignment
public class RandomWrapper : IRandom
{
    private readonly Random _random = new Random();

    public int Next(int maxValue)
    {
        return _random.Next(maxValue);
    }

    public int Next(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }
}