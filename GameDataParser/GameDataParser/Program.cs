// See https://aka.ms/new-console-template for more information
using GameDataParser.Data;
using GameDataParser.Objects;
using GameDataParser.UI;


try
{
    GameDataParserConsoleInterface UserInterface = new ();
    VideoGamesRepository GamesRepository = new();
    GameDataParserApp app = new(
        UserInterface, 
        GamesRepository
    );

    app.Start();
}
catch(Exception ex)
{
    Logger.LogException(ex);

    Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
    Console.WriteLine("Press any key to close");
    Console.ReadKey();
}
