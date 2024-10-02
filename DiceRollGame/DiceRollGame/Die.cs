namespace DiceRollGame;

public class Die
{
    public const int MinNumber = 1;
    public const int MaxNumber = 6;
    private static Random rnd = new Random();

    public int NumberOnTop { get; private set; }

    public Die() 
    {
        NumberOnTop = 1;
    }

    public int RollDie()
    {
        NumberOnTop = rnd.Next(MinNumber, MaxNumber + 1);
        return NumberOnTop;
    }

}
