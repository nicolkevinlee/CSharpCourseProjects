using System.Text.RegularExpressions;

namespace QuoteFinder.UI;

public class ConsoleInterface : IUserInterface
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string ReadSingleWord(string promptMessage)
    {
        do
        {
            Console.WriteLine(promptMessage);

            var input = Console.ReadLine();

            if (IsSingleWord(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        } while (true);
    }

    public int ReadInteger(string promptMessage)
    {
        do
        {
            Console.WriteLine(promptMessage);

            var input = Console.ReadLine();
            bool success = int.TryParse(input!, out var value);

            if (success)
            {
                return value;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        } while (true);
    }

    public bool ReadBool(string promptMessage)
    {
        do
        {
            Console.WriteLine(promptMessage + " [Y/N]");

            var input = Console.ReadLine();

            if (IsYesOrNo(input))
            {
                input = input.ToLower();
                if (input == "y") return true;
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        } while (true);
    }

    private bool IsSingleWord(string? word)
    {
        if (string.IsNullOrEmpty(word)) return false;
        var regexItem = new Regex("^[a-zA-Z]+$");
        return regexItem.IsMatch(word);
    }

    private bool IsYesOrNo(string? input)
    {
        if (string.IsNullOrEmpty(input)) return false;
        input = input.ToLower();
        return (input == "y" || input == "n");
    }
}
