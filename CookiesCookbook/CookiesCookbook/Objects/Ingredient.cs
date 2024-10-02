using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Objects;

public class Ingredient
{
    public int ID { get; init; }
    public string Name { get; init; }
    public string Instructions { get; init; }

    public override string ToString()
    {
        return $"{Name}. {Instructions}";
    }
}
