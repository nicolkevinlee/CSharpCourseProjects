namespace CookiesCookbook;

internal class Program
{
    private static void Main(string[] args)
    {
        CookiesCookbook cookbook = new CookiesCookbook();

        cookbook.Start();

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}