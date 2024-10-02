using NUnit.Framework;
using FibonacciGeneratorApp;
using NUnit.Framework.Legacy;
using System.Collections;

namespace FibonacciGeneratorTests;

[TestFixture]
public class FibonacciGeneratorTests
{
    [TestCase(-1)]
    [TestCase(47)]
    public void Generate_ReturnsException_ForNotInRange(int input)
    {
        Assert.Throws<ArgumentException>(()=> FibonacciGenerator.Generate(input));
    }


    [TestCaseSource(nameof(GetGenerateTestCases))]
    public void Generate_ReturnValidValue_ForInRange(int input, IEnumerable<int> expected)
    {
        var result = FibonacciGenerator.Generate(input);
        ClassicAssert.AreEqual(expected, result);
    }

    public static IEnumerable GetGenerateTestCases()
    {
        return new[]
        {
            new object[] { 0 , new List<int> { } },
            new object[] { 1 , new List<int> { 0 } },
            new object[] { 2 , new int[] { 0, 1 } },
            new object[] { 3 , new int[] { 0, 1, 1 } },
            new object[] { 4 , new int[] { 0, 1, 1, 2 } },
            new object[] { 5 , new int[] { 0, 1, 1, 2, 3 } },
            new object[] { 6 , new int[] { 0, 1, 1, 2, 3, 5 } },
            new object[] { 7 , new int[] { 0, 1, 1, 2, 3, 5, 8 } },
            new object[] { 8 , new int[] { 0, 1, 1, 2, 3, 5, 8, 13 } },
            new object[] { 9 , new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21 } }
        };
    }
}