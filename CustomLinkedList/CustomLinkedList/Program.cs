// See https://aka.ms/new-console-template for more information

var tests = new CustomLinkedList<string>() { "aaa", "bbb", "ccc" };

PrintList(tests);
TestAdd(tests);
PrintList(tests);

TestRemove(tests);
PrintList(tests);

TestContains(tests);
PrintList(tests);

Console.WriteLine("Test CopyTo");
var copied = new string[10];
tests.CopyTo(copied, 4);
//PrintList(tests);

foreach(var item in copied) { 
Console.WriteLine(item);
}


Console.ReadKey();

void PrintList(CustomLinkedList<string> tests)
{
    Console.WriteLine();
    Console.WriteLine($"Print List Count: {tests.Count}");
    foreach (var test in tests)
    {
        Console.WriteLine(test);
    }
    Console.WriteLine();
}

void TestAdd(CustomLinkedList<string> tests)
{

    Console.WriteLine($"Test Add Count: {tests.Count}");
    tests.AddToFront(null);
    tests.AddToFront("ddd");
    tests.AddToBack(null);
    tests.AddToBack("eee");
    tests.Add("fff");
    tests.Add("ggg");
    Console.WriteLine($"End Test Add Count: {tests.Count}");
    Console.WriteLine();
}

void TestRemove(CustomLinkedList<string> tests)
{

    Console.WriteLine($"Test Remove Count: {tests.Count}");
    Console.WriteLine("Remove null: " + tests.Remove(null));
    Console.WriteLine("Remove bbb: " + tests.Remove("bbb"));
    Console.WriteLine("Remove fff: " + tests.Remove("fff"));
    Console.WriteLine("Remove zzz: " + tests.Remove("zzz"));
    Console.WriteLine($"Test Remove Count: {tests.Count}");
    Console.WriteLine();
}

void TestContains(CustomLinkedList<string> tests)
{

    Console.WriteLine($"Test Contains Count: {tests.Count}");
    Console.WriteLine("Contains null: " + tests.Contains(null));
    Console.WriteLine("Contains zzz: " + tests.Contains("zzz"));
    Console.WriteLine("Contains ddd: " + tests.Contains("ddd"));
    Console.WriteLine($"Test Contains Count: {tests.Count}");
    Console.WriteLine();
}
