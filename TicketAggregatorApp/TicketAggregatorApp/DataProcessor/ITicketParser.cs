// See https://aka.ms/new-console-template for more information

namespace TicketAggregatorApp.DataProcessor;
internal interface ITicketParser
{
    List<TicketDetails> GetTicketDetailsFromText(string text);
    List<TicketDetails> GetTicketDetailsFromText(string[] texts);
}