public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        var chars = text.Select(ch =>
        {
            if (!char.IsAsciiLetter(ch))
            {
                return ch;
            }

            char shifted = (char)(ch + shiftKey);

            if (!char.IsAsciiLetter(shifted) || char.IsLower(shifted) != char.IsLower(ch))
            {
                return (char)(shifted - 26);
            }

            return shifted;

        }).ToArray();
        
        return string.Join("", chars);
    }

}