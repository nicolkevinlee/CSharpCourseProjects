namespace DiceRollGame;

public static class Validator
{
    public static bool CheckIfInputIsNumber(string input, out int number)
    {
        bool result = int.TryParse(input, out number);
        if (!result) Console.WriteLine("Incorrect input.");
        return result;
    }

    public static int GetInput()
    {
        int number;
        string numberInString;
        do
        {
            Console.WriteLine("Enter a number:");
            numberInString = Console.ReadLine();
        } while (!CheckIfInputIsNumber(numberInString, out number));

        return number;
    }

}
