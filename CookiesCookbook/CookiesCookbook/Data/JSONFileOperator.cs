using CookiesCookbook.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookiesCookbook.Data;

public class JSONFileOperator : FileOperator
{
    public JSONFileOperator()
    {
        filename = "recipes.json";
    }

    public override void SaveToFile(string recipeListAsStrings)
    {
        
        List<string> recipes = ReadFromFile();
        if(recipes is null) recipes = new List<string>();
        recipes.Add(recipeListAsStrings);
        string jsonString = JsonSerializer.Serialize(recipes);
        File.WriteAllText(filename, jsonString);

    }

    public override List<string> ReadFromFile()
    {
        try
        {
            string textFromFile = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<string>>(textFromFile);
        }
        catch (Exception)
        {
            return null;
        }
    }
    
}
