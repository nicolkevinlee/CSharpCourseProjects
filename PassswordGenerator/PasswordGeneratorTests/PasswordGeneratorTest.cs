using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;

namespace PasswordGeneratorTests;

[TestFixture]
public class PasswordGeneratorTest
{
    private Mock<IRandom> _randomMock;
    private PasswordGenerator _cut;

    [SetUp]
    public void SetUp()
    {
        _randomMock = new Mock<IRandom> ();
        _cut = new PasswordGenerator(_randomMock.Object);

    }

    [TestCase(0, 1)]
    [TestCase(-1, 9)]
    [TestCase(-10, 50)]
    [TestCase(-100, 50)]
    public void Generate_ShallReturnException_IfMinLessThanOrEqualToZero(int minLength, int maxLength)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            _cut.GenerateWithRange(minLength, maxLength, false));
    }

    [TestCase(10, 1)]
    [TestCase(10, 9)]
    [TestCase(100, 50)]
    public void Generate_ShallReturnException_IfMinLengthIsGreaterThanMaxLength(int minLength, int maxLength)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            _cut.GenerateWithRange(minLength, maxLength, false));
    }

    [TestCase(1, 10)]
    [TestCase(10, 30)]
    [TestCase(20, 100)]
    public void Generate_ShallReturnNoException_WithValidRange(int minLength, int maxLength)
    {
        Assert.DoesNotThrow(() =>
            _cut.GenerateWithRange(minLength, maxLength, false));
    }

    [TestCase(1, 10, "AEJOT", new int[] { 0, 4, 9, 14, 19 })]
    public void Generate_ReturnsPassword_WithinRange_NoSpecialCharacters(int minLength, int maxLength, string expectedPassword, int[] indexes)
    {

        GenerateMockPasswordLength(minLength, maxLength, expectedPassword.Length);
        GenerateMockPassword(indexes);

        var password = _cut.GenerateWithRange(minLength, maxLength, false);

        ClassicAssert.AreEqual(expectedPassword, password);
    }

    [TestCase(1,10, "AKU4%", new int[] {0, 10, 20, 30, 40})]
    public void Generate_ReturnsPassword_WithinRange_WithSpecialCharacters(int minLength, int maxLength, string expectedPassword, int[] indexes)
    {

        GenerateMockPasswordLength(minLength, maxLength, expectedPassword.Length);
        GenerateMockPassword(indexes);

        var password = _cut.GenerateWithRange(minLength, maxLength, true);

        ClassicAssert.AreEqual(expectedPassword, password);
    }

    private void GenerateMockPasswordLength(int minLength, int maxLength, int lengthToGenerate) 
    {
        _randomMock
            .Setup(mock => mock.Next(minLength, maxLength + 1))
            .Returns(lengthToGenerate);
    }

    private void GenerateMockPassword(int[] characterSetIndices)
    {
        var sequence = _randomMock
            .SetupSequence(mock => mock.Next(It.IsAny<int>()));

        foreach(var index in characterSetIndices)
        {
            sequence = sequence.Returns(index);
        }
    }
}