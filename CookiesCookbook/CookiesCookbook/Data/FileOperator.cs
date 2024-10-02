using CookiesCookbook.Objects;

namespace CookiesCookbook.Data;

public abstract class FileOperator
{

    protected string filename = "recipe";

    public abstract void SaveToFile(string recipeListAsStrings);
    public abstract List<string> ReadFromFile();
}
