// See https://aka.ms/new-console-template for more information
namespace TicketAggregatorApp.DataAccessor;
internal interface ITicketFileReader
{
    string GetTicketDetailsFromFile(string fileName);
    string[] GetTicketDetailsFromFiles(string[] files);
}