using System.Globalization;
using System.Runtime.CompilerServices;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        int centerSize = studentA.Length + studentB.Length + 3;
        int leftPadding = (61 - centerSize)/2 - 1;
        int rightPadding = (61 - centerSize) - leftPadding;
        return new string(' ', leftPadding) + $"{studentA} ♡ {studentB}" + new string(' ', rightPadding);
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        string topHalf = """
                           
                               ******       ******
                             **      **   **      **
                           **         ** **         **
                          **            *            **
                          **                         **
                          """;

        var namesA = studentA.Split(' ');
        var namesB = studentB.Split(' ');
        string middle = $"**     {namesA[0][0]}. {namesA[1][0]}.  +  {namesB[0][0]}. {namesB[1][0]}.     **";
        
        string bottomHalf = """
                              **                       **
                                **                   **
                                  **               **
                                    **           **
                                      **       **
                                        **   **
                                          ***
                                           *
                             """;
        
        return $"{topHalf}\n{middle}\n{bottomHalf}";
    }

    public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours)
    {
        var text = FormattableStringFactory.Create(
            "{0} and {1} have been dating since {2} - that's {3:N2} hours", 
            studentA, studentB,  DateOnly.FromDateTime(start), hours); 
        
        return text.ToString(new CultureInfo("de-DE"));
    }
}
