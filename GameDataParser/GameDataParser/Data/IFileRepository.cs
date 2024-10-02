using GameDataParser.Objects;

namespace GameDataParser.Data;

public interface IFileRepository
{
    List<VideoGame> GetGameDataFromFile(string fileName);
}
