using GameDataParser.Objects;

namespace GameDataParser.UI;

public class GameDataParserConsoleInterface : IUserInterface
{
    public void PrintVideoGameList(List<VideoGame> videoGames)
    {
        if (videoGames.Count <= 0)
        {
            Console.WriteLine("No games are present in the input file.");
        }
        else
        {
            Console.WriteLine("Loaded games are:");
            foreach (VideoGame videoGame in videoGames)
            {
                Console.WriteLine(videoGame);
            }
        }
        Console.WriteLine();
    }

    public string PromptFilenameFromUser()
    {
        bool isFilenameValid = false;
        string fileName;

        do
        {

            Console.WriteLine("Enter the name of the file you want to read:");
            fileName = Console.ReadLine();
            Console.WriteLine();

            if (fileName is null)
            {
                Console.WriteLine("File name cannot be null." + Environment.NewLine);
                continue;
            }

            fileName = fileName.Trim();

            if (fileName.Equals(string.Empty))
            {
                Console.WriteLine("File name cannot be empty." + Environment.NewLine);
                continue;
            }

            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found." + Environment.NewLine);
                continue;
            }

            isFilenameValid = true;

        } while (!isFilenameValid);

        return fileName;
    }

    public void ShowExit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
