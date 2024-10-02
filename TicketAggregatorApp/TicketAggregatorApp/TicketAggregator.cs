// See https://aka.ms/new-console-template for more information

using TicketAggregatorApp.DataAccessor;
using TicketAggregatorApp.DataProcessor;

namespace TicketAggregatorApp;

internal class TicketAggregator
{
    private IFileAccessor _fileAccessor;
    private ITicketFileReader _ticketFileReader;
    private ITicketParser _ticketParser;

    public TicketAggregator(IFileAccessor fileAccessor, ITicketFileReader ticketFileReader, ITicketParser ticketParser)
    {
        _fileAccessor = fileAccessor;
        _ticketFileReader = ticketFileReader;
        _ticketParser = ticketParser;
    }

    public void Run()
    {
        var pdfFiles = _fileAccessor.GetFileNamesFromDirectory();
        var texts = _ticketFileReader.GetTicketDetailsFromFiles(pdfFiles);
        var ticketDetails = _ticketParser.GetTicketDetailsFromText(texts);
        _fileAccessor.WriteToFile(String.Join(Environment.NewLine, ticketDetails.Select(ticket => ticket.ToString())));

    }
}