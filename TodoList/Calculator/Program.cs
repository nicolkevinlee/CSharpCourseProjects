Console.WriteLine("Hello!\nInput the first number.");
int first = int.Parse(Console.ReadLine());
Console.WriteLine("Input the second number.");
int second = int.Parse(Console.ReadLine());
Console.WriteLine();
Console.WriteLine("What do you want to do with those numbers?");
Console.WriteLine("[A]dd");
Console.WriteLine("[S]ubtract");
Console.WriteLine("[M]ultiply");
Console.Write("\nInput: ");
string option = Console.ReadLine();
Console.WriteLine();

if (option != null)
{
    if(IsEqualCaseInsensitive(option, "A"))
    {
        PrintEquation(first, second, (first + second), "+");
    }
    else if(IsEqualCaseInsensitive(option, "S"))
    {
        PrintEquation(first, second, (first - second), "-");
    }
    else if(IsEqualCaseInsensitive(option, "M"))
    {
        PrintEquation(first, second, (first * second), "*");
    }
    else
    {
       PrintInvalidInput();
    }
}
else
{
    PrintInvalidInput();
}


Console.WriteLine("Press any key to close.");
Console.ReadKey();


void PrintInvalidInput()
{
    Console.WriteLine("Invalid option\n");
}

void PrintEquation(int first, int second,  int result, string @operator)
{
    Console.WriteLine($"{first} {@operator} {second} = {result}");
}

bool IsEqualCaseInsensitive(string left, string right)
{
    return left.ToUpper() == right.ToUpper();
}