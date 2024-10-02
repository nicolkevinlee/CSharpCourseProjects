var toDoList = new List<string>();
var willExit = false;

Console.WriteLine("Hello!");

do
{
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    Console.Write("\nInput:");
    string userChoice = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("User input: " + userChoice);

    switch(userChoice)
    {
        case "S":
        case "s":
            PrintSelectedOption("See all TODOs");
            SeeAllTODOs();
            continue;
        case "A":
        case "a":
            PrintSelectedOption("Add a TODO");
            AddTODO();
            continue;
        case "R":
        case "r":
            PrintSelectedOption("Remove TODOs");
            RemoveTodo();
            continue;
        case "E":
        case "e":
            PrintSelectedOption("Exit");
            willExit = true;
            continue;
        default:
            Console.WriteLine("Invalid Input");
            continue;
    }

} while (!willExit);

Console.ReadKey();



void PrintSelectedOption(string selectionOption)
{
    Console.WriteLine("Selected: " + selectionOption);
}

void SeeAllTODOs()
{
    if (toDoList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
    }

    for(var i = 0; i < toDoList.Count; ++i)
    {
        Console.WriteLine($"{i + 1}. {toDoList[i]}");
    }
}
void AddTODO()
{
    bool isUnique = false;
    string todo;
    do
    {
        Console.Write("Enter the TODO description: ");
        todo = Console.ReadLine();
        Console.WriteLine();
        todo = todo.Trim();

        if(todo.Length == 0)
        {
            Console.WriteLine("The description cannot be empty.\n");
            continue;
        }

        isUnique = CheckUniqueTODO(todo);

        if (!isUnique)
        {
            Console.WriteLine("The description must be unique.\n");
            continue;
        }


    }
    while (!isUnique);


    toDoList.Add(todo);
    Console.WriteLine($"TODO successfully added: {todo}\n");
}


bool CheckUniqueTODO(string description)
{
    if (toDoList.Contains(description)) return false;

    foreach (var todo in toDoList)
    {
        if(todo.ToLower() == description.ToLower())
        {
            return false;
        }
    }

    return true;
}


void RemoveTodo()
{
    do
    {

        if (toDoList.Count == 0)
        {
            Console.WriteLine("No TODOs have been added yet.");
            return;
        }

        int index = -1;
        Console.WriteLine("Select the index of the TODO you want to remove: ");

        SeeAllTODOs();
        string indexStr = Console.ReadLine();
        Console.WriteLine();

        indexStr = indexStr.Trim();

        if(indexStr.Length == 0)
        {
            Console.WriteLine("Selected index cannot be empty.\n");
            continue;
        }


        bool success = int.TryParse(indexStr, out index);

        if (!success)
        {
            Console.WriteLine("The given index is not valid.\n");
            continue;
        }

        index--;
        if (index < 0 || index >= toDoList.Count)
        {
            Console.WriteLine("The given index is not valid.\n");
            continue;
        }
        
        var toRemove = toDoList[index];
        toDoList.RemoveAt(index);

        Console.WriteLine($"TODO removed: {toRemove}\n");
        break;
    }
    while (true);
}

