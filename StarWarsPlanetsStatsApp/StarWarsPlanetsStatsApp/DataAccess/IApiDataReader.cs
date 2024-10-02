// See https://aka.ms/new-console-template for more information
namespace StarWarsPlanetsStatsApp.DataAccess;

public interface IDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
}