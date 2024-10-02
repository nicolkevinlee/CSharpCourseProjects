// See https://aka.ms/new-console-template for more information
using System.Globalization;

namespace TicketAggregatorApp.DataProcessor;
internal record TicketDetails
{
    public required string Title { get; init; }
    public DateTime ScreenTime { get; init; }

    public override string ToString()
    {
        return $"{Title,-30} | {ScreenTime.ToString("d", CultureInfo.InvariantCulture)} | {ScreenTime.ToString("t", CultureInfo.InvariantCulture)}";
    }

}

