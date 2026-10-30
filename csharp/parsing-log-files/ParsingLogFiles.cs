using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        return Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");
    }

    public string[] SplitLogLine(string text)
    {
        return Regex.Split(text, @"<[*=^-]*>");
    }

    public int CountQuotedPasswords(string lines)
    {
        return Regex.Count(lines, @"(?i)password.*\n");
    }

    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, @"end-of-line[0-9]*", "");
    }

    private string PrefixOffendingPassword(string line)
    {
        var match = Regex.Match(line, @"(?i)(?<!.\S)password[\S]+");
        return match.Success ? $"{match.Value}: {line}" : $"--------: {line}";
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        return lines.Select(PrefixOffendingPassword).ToArray();
    }
}
