// See https://aka.ms/new-console-template for more information
using GameDataParser.Data;
using GameDataParser.Objects;
using GameDataParser.UI;

public class GameDataParserApp
{
    private IUserInterface _mainUserInterface;
    private IFileRepository _mainRepository;

    public GameDataParserApp(IUserInterface mainUserInterface, IFileRepository mainRepository)
    {
        _mainUserInterface = mainUserInterface;
        _mainRepository = mainRepository;
    }   

    public void Start()
    {
        List<VideoGame> videoGames;
        string fileName = _mainUserInterface.PromptFilenameFromUser();

        videoGames = _mainRepository.GetGameDataFromFile(fileName);

        _mainUserInterface.PrintVideoGameList(videoGames);
        _mainUserInterface.ShowExit();

    }
}
