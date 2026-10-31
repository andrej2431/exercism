public static class NucleotideCount
{
    
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> hist = new()
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0,
        };
        
        foreach (var c in sequence)
        {
            if (!hist.ContainsKey(c))
                throw new ArgumentException($"Sequence contains non-unique character: {c}");
            
            hist[c]++;
        }
        return hist;
    }
}