// See https://aka.ms/new-console-template for more information
using StarWarsPlanetsStatsApp.Printer;
using StarWarsPlanetsStatsApp.Processors;
using StarWarsPlanetsStatsApp.UI;
using StarWarsPlanetsStatsApp.Enums;

var App = new PlanetsStatsApp();

await App.StartAsync();


public class PlanetsStatsApp
{

    private ApiDataReader _apiReader;
    private StarWarsPlanetsJSONRepository _jsonRepository;
    private TablePrinter _printer;
    private Calculator _calculator;
    private ConsoleInterface _consoleInterface;

    public PlanetsStatsApp()
    {
        _apiReader = new ApiDataReader();
        _jsonRepository = new StarWarsPlanetsJSONRepository(_apiReader);
        _printer = new TablePrinter();
        _calculator = new Calculator();
        _consoleInterface = new ConsoleInterface(_calculator);
    }

    public async Task StartAsync() {

        var planets = await _jsonRepository.GetPlanets();
        _printer.PrintCollection(planets);

        var property = _consoleInterface.PromptUserForProperty();
        _consoleInterface.ShowStatisticsForProperty(planets, property);

        Console.ReadKey();
    }
}