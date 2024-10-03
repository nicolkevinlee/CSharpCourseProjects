// See https://aka.ms/new-console-template for more information
using QuoteFinder.DataAccess;
using QuoteFinder.DataAccess.Mock;
using QuoteFinder.Model;
using QuoteFinder.UI;
using System.Diagnostics;
using System.Text.Json;


try
{

    var consoleInterface = new ConsoleInterface();
   
    var word = consoleInterface.ReadSingleWord("What word are you looking for?");
    var pages = consoleInterface.ReadInteger("How many pages do you want to read?");
    var quotesPerPage = consoleInterface.ReadInteger("How many quotes per page?");
    var isParallel = consoleInterface.ReadBool("Process in parallel?");


    var task = SearchQuotes(word, pages, quotesPerPage, isParallel);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();


async Task SearchQuotes(string word, int pages, int quotesPerPage, bool isParallel)
{
    var results = await FetchQuotes(pages, quotesPerPage);
    var quotes = await ProcessQuotes(results, word,isParallel);
    PrintQUuotes(quotes);
}

async Task<List<string>> FetchQuotes(int pages, int quotesPerPage)
{
    var quotesApiReader = new MockQuotesApiDataReader();
    var tasks = new List<Task<string>>();
    for(int i = 1; i <= pages; ++i)
    {
        var fetchTask = quotesApiReader.ReadAsync(i, quotesPerPage);
        tasks.Add(fetchTask);
    }

    return (await Task.WhenAll(tasks)).ToList();
}

async Task<List<Datum?>> ProcessQuotes(List<string> data, string word, bool isParallel)
{
    if (isParallel)
    {
        var tasks = data.Select(d => Task.Run(() => ProcessPage(d, word))).ToList();
        return (await Task.WhenAll(tasks)).ToList();
    }
    else
    {
        return data.Select(d => ProcessPage(d, word)).ToList();
    }
    
}

Datum? ProcessPage(string page, string word)
{
    var root = JsonSerializer.Deserialize<Root>(page);

    return root?.data.Where(q => ContainsWord(q.quoteText, word))
        .OrderBy(q => q.quoteText.Length)
        .FirstOrDefault();
}

bool ContainsWord(string text, string word)
{
    var textInLower = text.ToLower();
    var wordInLower = word.ToLower();

    return textInLower.Split(' ').Any(t => t == wordInLower);
}

void PrintQUuotes(List<Datum?> quotes)
{
    var consoleInterface = new ConsoleInterface();
    foreach (var quote in quotes)
    {
        if (quote == null)
        {
            consoleInterface.ShowMessage("No quote found on this page.\n");
        }
        else
        {
            consoleInterface.ShowMessage($"{quote.quoteText} -- {quote.quoteAuthor}\n");
        }
    }
    
}




