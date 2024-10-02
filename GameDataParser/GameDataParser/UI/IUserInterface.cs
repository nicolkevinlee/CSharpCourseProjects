using GameDataParser.Objects;

namespace GameDataParser.UI;

public interface IUserInterface
{
    void ShowMessage(string message);
    void ShowExit();
    void PrintVideoGameList(List<VideoGame> videoGames);
    string PromptFilenameFromUser();
}
