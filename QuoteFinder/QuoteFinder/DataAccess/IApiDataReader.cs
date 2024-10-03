// See https://aka.ms/new-console-template for more information
namespace QuoteFinder.DataAccess;

public interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
    Task<string> Read(string endpoint);
}