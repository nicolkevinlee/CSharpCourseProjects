// See https://aka.ms/new-console-template for more information
using QuoteFinder.DataAccess;

public class ApiDataReader : IApiDataReader
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

    public async Task<string> Read(string endpoint)
    {
        using var httpClient = new HttpClient();

        HttpResponseMessage responseMessage = await httpClient.GetAsync(endpoint);
        // throw exception if not success
        responseMessage.EnsureSuccessStatusCode();

        return await responseMessage.Content.ReadAsStringAsync();
    }
}
