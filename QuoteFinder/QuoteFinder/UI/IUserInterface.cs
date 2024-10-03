namespace QuoteFinder.UI;

public interface IUserInterface
{
    void ShowMessage(string message);
    string ReadSingleWord(string promptMessage);
    int ReadInteger(string promptMessage);
}
