using Game;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using UserCommunication;

namespace DiceRollGameAppTests;

[TestFixture]
public class DiceRollGameAppTests
{
    private Mock<IUserCommunication> _userCommunicationMock;
    private Mock<IDice> _diceMock;
    private GuessingGame _cut;

    [SetUp]
    public void SetUp()
    {
        _diceMock = new Mock<IDice>();
        _userCommunicationMock = new Mock<IUserCommunication>();
        _cut = new GuessingGame(
            _diceMock.Object,
            _userCommunicationMock.Object);
    }


    [Test]
    public void Play_ReturnsVictory_WithFirstTry()
    {
        const int countOnDie = 4;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(countOnDie);

        _userCommunicationMock
            .Setup(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(countOnDie);

        var result = _cut.Play();

        ClassicAssert.AreEqual(GameResult.Victory, result);

    }

    [Test]
    public void Play_ReturnsVictory_WithThirdTry()
    {
        SetupMockVictoryThreeTries();

        var result = _cut.Play();

        ClassicAssert.AreEqual(GameResult.Victory, result);

    }


    [Test]
    public void Play_ReturnsLoss_WithFourthTry()
    {

        SetupMockLoss();

        var result = _cut.Play();

        ClassicAssert.AreEqual(GameResult.Loss, result);

    }

    [Test]
    public void Play_VerifyReadInteger_IfExecutedThreeTimes_OnVictoryThreeTries()
    {

        SetupMockVictoryThreeTries();
        var result = _cut.Play();

        _userCommunicationMock.Verify(mock => mock.ReadInteger("Enter a number:"), Times.Exactly(3));

    }

    [Test]
    public void Play_VerifyReadInteger_IfExecutedThreeTimes_OnLoss()
    {

        SetupMockLoss();
        var result = _cut.Play();

        _userCommunicationMock.Verify(mock => mock.ReadInteger("Enter a number:"), Times.Exactly(3));

    }

    [Test]
    public void Play_VerifyShowMessage_IfShowedDicedRollMessage()
    {

        var result = _cut.Play();

        _userCommunicationMock.Verify(mock => mock.ShowMessage("Dice rolled. Guess what number it shows in 3 tries."), Times.Once);

    }


    [Test]
    public void Play_VerifyShowMessage_IfShowedWrongNumberThreeTimes_OnVictoryThreeTries()
    {
        SetupMockVictoryThreeTries();

        var result = _cut.Play();

        _userCommunicationMock.Verify(mock => mock.ShowMessage("Wrong number."), Times.Exactly(2));

    }

    [Test]
    public void Play_VerifyShowMessage_IfShowedWrongNumberThreeTimes_OnLoss()
    {
        SetupMockLoss();

        var result = _cut.Play();

        _userCommunicationMock.Verify(mock => mock.ShowMessage("Wrong number."), Times.Exactly(3));

    }

    [TestCase(GameResult.Victory, "You win!")]
    [TestCase(GameResult.Loss, "You lose :(")]
    public void PrintResult_ShowsCorrectMessage(GameResult result, string message)
    {
        _cut.PrintResult(result);

        _userCommunicationMock.Verify(mock => mock.ShowMessage(message));

    }

    private void SetupMockLoss()
    {
        const int countOnDie = 4;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(countOnDie);

        _userCommunicationMock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(1)
            .Returns(2)
            .Returns(3)
            .Returns(countOnDie);
    }

    private void SetupMockVictoryThreeTries()
    {
        const int countOnDie = 4;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(countOnDie);

        _userCommunicationMock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(1)
            .Returns(2)
            .Returns(countOnDie);
    }
}

