namespace QuoteFinder.DataAccess;

public interface IQuotesAPIDataReader
{
    Task<string> ReadAsync(int page, int quotesPerPage);
}
