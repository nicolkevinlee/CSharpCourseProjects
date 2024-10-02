namespace DiceRollGame;

internal class Program
{
    

    static void Main(string[] args)
    {
        DiceGame diceGame = new DiceGame();
        GameResult result = diceGame.StartGame();

        Console.ReadKey();
       
    }
}
