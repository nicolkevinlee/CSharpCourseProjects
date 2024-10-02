// See https://aka.ms/new-console-template for more information
using StarWarsPlanetsStatsApp.DataAccess;

public class ApiDataReader : IDataReader
{
    public async Task<string> Read(string baseAddress, string requestUri)
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri);
        // throw exception if not success
        responseMessage.EnsureSuccessStatusCode();

        return await responseMessage.Content.ReadAsStringAsync();
    }
}
