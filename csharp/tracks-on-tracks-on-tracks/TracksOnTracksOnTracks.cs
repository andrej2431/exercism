public static class Languages
{
    public static List<string> NewList()
    {
        return [];
    }

    public static List<string> GetExistingLanguages()
    {
        return ["C#", "Clojure", "Elm"];
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
        
    }

    public static bool IsExciting(List<string> languages)
    {
        switch (languages.Count)
        {
            case > 0 when languages[0] == "C#":
            case >= 2 and <= 3 when languages[1] == "C#":
                return true;
            default:
                return false;
        }
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        languages.Sort();
        for (var i = 0; i < languages.Count - 1; i++)
        {
            if (languages[i] ==  languages[i + 1])
                return false;
        }

        return true;
    }
}
