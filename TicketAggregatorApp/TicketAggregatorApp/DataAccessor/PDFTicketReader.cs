using UglyToad.PdfPig;

namespace TicketAggregatorApp.DataAccessor;
internal class PDFTicketReader : ITicketFileReader
{
    public string GetTicketDetailsFromFile(string fileName)
    {
        using (PdfDocument document = PdfDocument.Open(fileName))
        {
            return document.GetPage(1).Text;
        }
    }

    public string[] GetTicketDetailsFromFiles(string[] files)
    {
        return files.Select(file => GetTicketDetailsFromFile(file)).ToArray();
    }
}

