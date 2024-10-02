using StarWarsPlanetsStatsApp.Enums;
using StarWarsPlanetsStatsApp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetsStatsApp.Processors;

public class Calculator
{

    public Statistics<double?> GetStatisticForProperty(string propertyName, List<Planet> planets, Func<Planet, double?> propertySelector)
    {

        var minPlanet = planets.MinBy(propertySelector);
        var maxPlanet = planets.MaxBy(propertySelector);

        return new Statistics<double?>(propertyName, propertySelector(minPlanet!), propertySelector(maxPlanet!), minPlanet!.Name, maxPlanet!.Name);
    }



}
