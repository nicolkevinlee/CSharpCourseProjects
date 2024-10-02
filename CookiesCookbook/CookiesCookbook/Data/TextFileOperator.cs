


namespace CookiesCookbook.Data;

public class TextFileOperator : FileOperator
{
    public TextFileOperator()
    {
        filename = "recipes.txt";
    }

    public override void SaveToFile(string recipeListAsStrings)
    {

        List<string> recipes = ReadFromFile();
        if (recipes is null) recipes = new List<string>();
        recipes.Add(recipeListAsStrings);
        string textString = String.Join(Environment.NewLine, recipes);
        File.WriteAllText(filename, textString);

    }

    public override List<string> ReadFromFile()
    {
        try
        {
            string textFromFile = File.ReadAllText(filename);
            return textFromFile.Split(Environment.NewLine).ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }
}
