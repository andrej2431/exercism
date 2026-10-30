public static class LineUp
{
    private static string OrdinalSuffix(int number) =>
        number switch
        {
            1 => "st",
            2 => "nd",
            3 => "rd",
            _ => "th"
        };

    public static string Format(string name, int number) 
        => $"{name}, you are the {number}{OrdinalSuffix(number)} customer we serve today. Thank you!";
}
