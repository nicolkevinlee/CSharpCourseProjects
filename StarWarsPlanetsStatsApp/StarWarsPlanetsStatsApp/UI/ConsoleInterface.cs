using StarWarsPlanetsStatsApp.Enums;
using StarWarsPlanetsStatsApp.Objects;
using StarWarsPlanetsStatsApp.Processors;
using System.Numerics;

namespace StarWarsPlanetsStatsApp.UI;

public class ConsoleInterface : IUserInterface
{
    private readonly Calculator _calculator;
    private readonly string[] _enumNames;
    private readonly Dictionary<PlanetProperties, Func<Planet, double?>> _propertySelectorMappings;

    public ConsoleInterface(Calculator calculator) 
    { 
        _calculator = calculator;
        _enumNames = Enum.GetNames(typeof(PlanetProperties));
        _propertySelectorMappings = new Dictionary<PlanetProperties, Func<Planet, double?>>
        {
            [PlanetProperties.Diameter] = planet => planet.Diameter,
            [PlanetProperties.SurfaceWater] = planet => planet.SurfaceWater,
            [PlanetProperties.Population] = planet => planet.Population
        };
    }

    public PlanetProperties PromptUserForProperty()
    {
        do
        {
            Console.WriteLine("The statistics of which property would you like to see?");
            foreach (string name in _enumNames)
            {
                Console.WriteLine(name);
            }
            var input = Console.ReadLine();

            if (_enumNames.Contains(input))
            {
                return Enum.Parse<PlanetProperties>(input!);
            }
            else
            {
                Console.WriteLine("Invalid choice" + Environment.NewLine);
            }
        }while (true) ;
    }

    public void ShowStatisticsForProperty(List<Planet> planets, PlanetProperties property)
    {
        Statistics<double?> stats = _calculator.GetStatisticForProperty(_enumNames[(int)property], planets, _propertySelectorMappings[property]);
        Console.WriteLine(stats);

    }
}
