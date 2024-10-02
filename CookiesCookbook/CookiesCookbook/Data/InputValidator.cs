using CookiesCookbook.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Data;

public static class InputValidator
{
    public static bool IsStringANumber(string input, out int number)
    {
        return int.TryParse(input, out number);
    }

    public static bool IsNumberAnIngredient(int input, List<Ingredient> ingredientList, out Ingredient ingredient)
    {
        ingredient = ingredientList.FirstOrDefault(ingredient => ingredient.ID == input);
        return (ingredient != null);
    }
}
