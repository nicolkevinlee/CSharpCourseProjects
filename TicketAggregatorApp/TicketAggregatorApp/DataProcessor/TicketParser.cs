// See https://aka.ms/new-console-template for more information
using System.Globalization;

namespace TicketAggregatorApp.DataProcessor;
internal class TicketParser : ITicketParser
{
    private string[] SEPARATORS = { "Title:", "Date:", "Time:", "Visit us:" };
    private Dictionary<string, CultureInfo> _localeMappings = new Dictionary<string, CultureInfo>
    {
        ["com"] = new CultureInfo("en-US"),
        ["fr"] = new CultureInfo("fr-FR"),
        ["jp"] = new CultureInfo("jp-JP")
    };


    public List<TicketDetails> GetTicketDetailsFromText(string text)
    {
        string[] splitted = text.Split(SEPARATORS, StringSplitOptions.None);
        var ticketDetails = new List<TicketDetails>((splitted.Length - 2) / 3);
        var locale = splitted[^1].Split('.')[^1];

        for (int i = 1; i < splitted.Length - 2; i = i + 3)
        {
            var title = splitted[i];
            var date = splitted[i + 1];
            var time = splitted[i + 2];

            ticketDetails.Add(new TicketDetails()
            {
                Title = title,
                ScreenTime = DateTime.Parse($"{date} {time}", _localeMappings[locale])
            });

        }
        return ticketDetails;
    }


    public List<TicketDetails> GetTicketDetailsFromText(string[] texts)
    {
        var ticketDetails = new List<TicketDetails>();
        foreach (var text in texts)
        {
            ticketDetails.AddRange(GetTicketDetailsFromText(text));
        }

        return ticketDetails;
    }

}

