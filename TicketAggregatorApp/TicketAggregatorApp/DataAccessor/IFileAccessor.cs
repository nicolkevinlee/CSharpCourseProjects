// See https://aka.ms/new-console-template for more information
namespace TicketAggregatorApp.DataAccessor;

internal interface IFileAccessor
{
    string[] GetFileNamesFromDirectory();

    void WriteToFile(string text);
}

