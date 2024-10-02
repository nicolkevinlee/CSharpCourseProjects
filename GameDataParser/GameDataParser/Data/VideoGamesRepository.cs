using GameDataParser.Objects;
using System.Text.Json;

namespace GameDataParser.Data;

public class VideoGamesRepository : IFileRepository
{

    public List<VideoGame> GetGameDataFromFile(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        try
        {

            List<VideoGame> videoGames = JsonSerializer.Deserialize<List<VideoGame>>(jsonString);
            return videoGames;

        }
        catch (JsonException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"JSON in the {fileName} was not in a valid format");
            Console.WriteLine($"JSON Body: {jsonString}");
            Console.ResetColor();
            throw new JsonException(ex.Message + $" The file is: {fileName}", ex);
        }
    }
}
