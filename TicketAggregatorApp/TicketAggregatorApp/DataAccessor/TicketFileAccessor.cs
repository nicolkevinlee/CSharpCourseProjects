// See https://aka.ms/new-console-template for more information

namespace TicketAggregatorApp.DataAccessor;
internal class TicketFileAccessor : IFileAccessor
{
    private const string PDF_DIRECTORY = "C:\\Users\\Nicol\\Documents\\Tickets";
    private const string AGGREGATED_FILE = "aggregatedTickets.txt";

    public string[] GetFileNamesFromDirectory()
    {
        try
        {
            return Directory.GetFiles(PDF_DIRECTORY, "Tickets*.pdf", SearchOption.TopDirectoryOnly);
        }
        catch (DirectoryNotFoundException ex)
        {
            throw new DirectoryNotFoundException($"Directory: {PDF_DIRECTORY} is not found.", ex);
        }
    }

    public void WriteToFile(string text)
    {
        File.WriteAllText(PDF_DIRECTORY + "/" + AGGREGATED_FILE, text);
    }
}

