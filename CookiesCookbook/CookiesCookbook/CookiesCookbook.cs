using CookiesCookbook.Data;
using CookiesCookbook.Objects;
using System.Text.Json;

namespace CookiesCookbook;

public class CookiesCookbook
{
    private List<Recipe> Recipes;
    private List<Ingredient> IngredientsList;
    private Recipe CurrentRecipe;
    private FileOperator FileOperator;

    public CookiesCookbook() {
        IngredientsList = JsonSerializer.Deserialize<List<Ingredient>>(IngredientDB.IngredientJSON);
        CurrentRecipe = new Recipe();
        FileOperator = new TextFileOperator();

        List<string> recipeStrings = FileOperator.ReadFromFile();
        if (recipeStrings != null) Recipes = RecipeParser.ParseRecipe(IngredientsList, recipeStrings);

    }

    public void Start()
    {
        PrintAllRecipes();
        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        PrintAllIngredients();
        CreateRecipe();

        if(CurrentRecipe.IngredientsList.Count > 0)
        {
            Console.WriteLine("\nRecipe added:");
            PrintRecipe(CurrentRecipe);
            SaveRecipes();
        }
        else
        {
            Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
        }
    }

    private void PrintRecipe(Recipe recipe)
    {
        Console.WriteLine(recipe);
    }

    public void PrintAllRecipes()
    {
        if (Recipes == null || Recipes.Count == 0) return;
        Console.WriteLine("Existing recipes are:\n");
        for(int i = 0; i < Recipes.Count; i++)
        {
            Console.WriteLine($"***** {i + 1} *****");
            PrintRecipe(Recipes[i]);
            Console.WriteLine();
        }

    }

    public void PrintAllIngredients()
    {
        var result = IngredientsList.Select(ingredient => $"{ingredient.ID}. {ingredient.Name}");
        Console.WriteLine(String.Join(Environment.NewLine, result));
        Console.WriteLine();
    }

    public void CreateRecipe()
    {
        string inputAsString = "";
        int input;
        bool isConstructing = true;
        bool isIngredient = false;
        Ingredient ingredient = null;

        while (isConstructing)
        {
            Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
            inputAsString = Console.ReadLine();
            isConstructing = InputValidator.IsStringANumber(inputAsString, out input);

            if (!isConstructing) continue;

            isIngredient = InputValidator.IsNumberAnIngredient(input, IngredientsList, out ingredient);

            if (isIngredient)
            {
                CurrentRecipe.AddIngredient(ingredient);
                Console.WriteLine($"{ingredient.Name} has been added to the recipe.\n");
            }
            else
            {
                Console.WriteLine("Ingredient is not found. Enter any available ingredient.\n");
            }
        } 
    }

    public void SaveRecipes()
    {
        string recipeString = RecipeParser.ConvertRecipeToString( CurrentRecipe );
        FileOperator.SaveToFile( recipeString );
    }
}
