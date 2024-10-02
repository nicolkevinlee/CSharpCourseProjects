// See https://aka.ms/new-console-template for more information
using StarWarsPlanetsStatsApp.DataAccess;
using StarWarsPlanetsStatsApp.Objects;
using System.Text.Json;

public class StarWarsPlanetsJSONRepository
{
    private const string BASE_ADDRESS = "https://swapi.dev/api/";
    private const string PLANETS_URI = "planets/";

    private readonly IDataReader _dataReader;

    public StarWarsPlanetsJSONRepository(IDataReader dataReader)
    {
        _dataReader = dataReader;
    }

    public async Task<List<Planet>> GetPlanets() 
    {
        bool isDataIncomplete = true;
        string uri = PLANETS_URI;
        List<PlanetRecord> planets = null;

        do
        {
            string resultInString = await _dataReader.Read(BASE_ADDRESS, uri);
            
            Root? root = JsonSerializer.Deserialize<Root>(resultInString);
            //throw error if null or error;
            if(planets is null && root.Count > 0)
            {
                planets = new List<PlanetRecord>(root.Count);
            }
            planets.AddRange(root.Results);

            if(root.Next != null)
            {
                uri = (root.Next.StartsWith(BASE_ADDRESS)) ? root.Next.Substring(BASE_ADDRESS.Length) : root.Next;
            }
            else
            {
                isDataIncomplete = false;
            }
        }
        while (isDataIncomplete);

        return planets.Select(pRecord => new Planet(pRecord)).ToList();
    }


}