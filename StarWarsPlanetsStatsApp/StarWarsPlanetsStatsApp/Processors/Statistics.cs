using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetsStatsApp.Processors;

public record Statistics<T>
{
    public string PropertyName { get; init; }
    public T Max { get; init; }
    public T Min { get; init; }
    public string MaxPlanetName { get; init; }
    public string MinPlanetName { get; init; }

    public Statistics(string propertyName, T min, T max, string minPlanetName, string maxPlanetname)
    {
        PropertyName = propertyName;
        Min = min;
        Max = max;
        MinPlanetName = minPlanetName;
        MaxPlanetName = maxPlanetname; 
    }
    public override string ToString()
    {

        var statsString = $"Max {PropertyName} is {Max}. (planet/s: {MaxPlanetName}){Environment.NewLine}";
        statsString += $"Min {PropertyName} is {Min}. (planet/s: {MinPlanetName})";
        return statsString;
    }
}
