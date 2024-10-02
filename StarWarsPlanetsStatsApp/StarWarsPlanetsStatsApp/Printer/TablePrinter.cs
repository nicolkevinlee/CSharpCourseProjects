using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetsStatsApp.Printer;

public class TablePrinter
{
    private const string _printFormat = "{0,-20}|";
    public void PrintCollection<T>(ICollection<T> collection)
    {
        Type collectionType = typeof(T);
        var properties = collectionType.GetProperties()
            .Where(p => p.Name != "EqualityContract");

        
        var header = properties.Select(property => String.Format(_printFormat, property.Name));


        Console.WriteLine(String.Join("", header));
        Console.WriteLine(new String('-', 21 * properties.Count()));

        foreach( var item in collection)
        {
            var row = properties.Select(property => String.Format(_printFormat, property.GetValue(item)));
            Console.WriteLine(String.Join("", row));
        }

        Console.WriteLine();

    }

    
}
