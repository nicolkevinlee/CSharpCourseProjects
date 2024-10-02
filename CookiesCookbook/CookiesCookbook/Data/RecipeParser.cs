using CookiesCookbook.Objects;

namespace CookiesCookbook.Data;

public class RecipeParser
{


    public static string ConvertRecipeToString(Recipe recipe)
    {

        var listID = recipe.IngredientsList.Select(ingredient => ingredient.ID);
        
        return String.Join(",", listID);
        
    }

    public static List<Recipe> ParseRecipe(List<Ingredient> ingredientList, List<string> recipesInString)
    {
        List<Recipe> recipes = recipesInString.Select(recipeString =>
        {
            Recipe recipe = new Recipe();
            string[] ingredientIDStrings = recipeString.Split(",");
            var ingredients = ingredientIDStrings
                .Select(id => int.Parse(id))
                .Select(ingredientID => ingredientList
                    .Where(ingredient => ingredient.ID == ingredientID)
                    .First());

            recipe.SetIngredients(ingredients.ToList());
            return recipe;
        }).ToList();
        return recipes;
    }
}
