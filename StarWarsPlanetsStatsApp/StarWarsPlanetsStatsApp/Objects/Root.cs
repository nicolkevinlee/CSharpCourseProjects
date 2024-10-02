// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;

public record Root(
    [property: JsonPropertyName("count")] int Count,
    [property: JsonPropertyName("next")] string? Next,
    [property: JsonPropertyName("previous")] string? Previous,
    [property: JsonPropertyName("results")] IReadOnlyList<PlanetRecord> Results
);
