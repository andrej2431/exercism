using System.Text.RegularExpressions;

static class LogLine
{
    public static string Message(string logLine)
    {
        var match = Regex.Match(logLine.Trim(), @"^\[.*\]: (.*)");
        return match.Groups[1].Value.Trim();
    }

    public static string LogLevel(string logLine)
    {
        var match = Regex.Match(logLine.Trim(), @"\[(.*)\].*");
        return match.Groups[1].Value.ToLowerInvariant();
    }

    public static string Reformat(string logLine)
    {
        var match = Regex.Match(logLine.Trim(), @"^\[(.*)\]: (.*)");

        return $"{(match.Groups[2].Value).Trim()} ({match.Groups[1].Value.Trim().ToLowerInvariant()})";
    }
}
