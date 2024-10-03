
using static System.Net.WebRequestMethods;

namespace QuoteFinder.DataAccess;

internal class QuotesAPIDataReader : IQuotesAPIDataReader
{
    private IApiDataReader _dataReader;
    private string _endPoint;
    public QuotesAPIDataReader(IApiDataReader dataReader)
    {  
        _dataReader = dataReader;
        _endPoint = "https://quote-garden.onrender.com/api/v3/quotes?";
    }

    public async Task<string> ReadAsync(int page, int quotesPerPage)
    {
        var fullEndPoint = $"{_endPoint}limit={quotesPerPage}&page={page}";
        var json = await _dataReader.Read(fullEndPoint);
        return json;
    }
}
