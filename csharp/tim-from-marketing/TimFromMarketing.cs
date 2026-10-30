static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string idString = id != null ? $"[{id}] - " : "";
        return $"{idString}{name} - {department?.ToUpper() ?? "OWNER"}";
    }
}
