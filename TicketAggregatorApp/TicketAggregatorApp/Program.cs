// See https://aka.ms/new-console-template for more information


using TicketAggregatorApp;
using TicketAggregatorApp.DataAccessor;
using TicketAggregatorApp.DataProcessor;

var aggregatorApp = new TicketAggregator(
    new TicketFileAccessor(),
    new PDFTicketReader(),
    new TicketParser());

aggregatorApp.Run();


Console.ReadKey();
