using System.Text.RegularExpressions;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimiter)
    {
        return Regex.Match(str, delimiter +@"(.*)").Groups[1].Value;
    }

    public static string SubstringBetween(this string str, string startDelim, string endDelim)
    {
        int start = str.IndexOf(startDelim, StringComparison.Ordinal);
        int end = str.IndexOf(endDelim, StringComparison.Ordinal);

        if (start < 0 || end < 0 || end < start)
        {
            return string.Empty;
        }
        
        return str.Substring(start + startDelim.Length, end - start - startDelim.Length);
    }

    public static string Message(this string str)
    {
        return Regex.Match(str.Trim(), @"\[.*\]: (.*)").Groups[1].Value;
    }

    public static string LogLevel(this string str)
    {
        return Regex.Match(str.Trim(), @"^\[(.*)\]: ").Groups[1].Value;
    }
}