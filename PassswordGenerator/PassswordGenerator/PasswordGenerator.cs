//the class to be refactored as an assignment
using System.Text;

public class PasswordGenerator
{
    private readonly IRandom _random;

    public PasswordGenerator(IRandom random)
    {
        _random = random;
    }

    public string GenerateWithRange(
        int minLength, int maxLength, bool useSpecialCharacters)
    {
        Validate(minLength, maxLength);

        var passwordLength = GeneratePasswordLength(minLength, maxLength);

        var characterSet = GetCharacterSet(useSpecialCharacters);

        return GeneratePassword(passwordLength, characterSet);
    }

    private static void Validate(int minLength, int maxLength)
    {
        if (minLength < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be greater than 0");
        }
        if (maxLength < minLength)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be smaller than {nameof(maxLength)}");
        }
    }
    private static string GetCharacterSet(bool useSpecialCharacters)
    {
        return useSpecialCharacters ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    }

    private int GeneratePasswordLength(int minLength, int maxLength)
    {
        return _random.Next(minLength, maxLength + 1);
    }
    
    private string GeneratePassword(int passwordLength, string characterSet)
    {
        var passwordBuilder = new StringBuilder(passwordLength);

        for(int i = 0; i < passwordLength; i++)
        {
            passwordBuilder.Append(characterSet[_random.Next(characterSet.Length)]);
        }

        return passwordBuilder.ToString();
    }
}
