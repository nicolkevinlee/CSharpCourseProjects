using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Objects;

public class Recipe
{
    public List<Ingredient> IngredientsList { get; private set; } = new List<Ingredient>();

    public void AddIngredient(Ingredient ingredient)
    {
        IngredientsList.Add(ingredient);
    }

    public void SetIngredients(List<Ingredient> ingredients)
    {
        IngredientsList = ingredients;
    }

    public override string ToString()
    {
        return String.Join(Environment.NewLine, IngredientsList);
    }
}
