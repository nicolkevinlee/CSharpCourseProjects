// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;

public record struct PlanetRecord(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("diameter")] string? Diameter,
    [property: JsonPropertyName("surface_water")] string? SurfaceWater,
    [property: JsonPropertyName("population")] string? Population
);
