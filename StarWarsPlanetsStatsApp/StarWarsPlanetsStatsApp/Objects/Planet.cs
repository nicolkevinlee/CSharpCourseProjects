using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetsStatsApp.Objects;

public class Planet
{
    public string Name { get; init; }
    public int? Diameter { get; init; }
    public float? SurfaceWater { get; init; }
    public long? Population { get; init; }

    public Planet(PlanetRecord planetRecord)
    {
        Name = planetRecord.Name;
        Diameter = (String.IsNullOrEmpty(planetRecord.Diameter) || planetRecord.Diameter.Equals("unknown")) ? null : int.Parse(planetRecord.Diameter);
        SurfaceWater = (String.IsNullOrEmpty(planetRecord.SurfaceWater) || planetRecord.SurfaceWater.Equals("unknown")) ? null : float.Parse(planetRecord.SurfaceWater);
        Population = (String.IsNullOrEmpty(planetRecord.Population) || planetRecord.Population.Equals("unknown")) ? null : long.Parse(planetRecord.Population);
    }

}
