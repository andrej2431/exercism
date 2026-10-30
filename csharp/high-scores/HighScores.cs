public class HighScores(List<int> list)
{
    private List<int> _scores = list;

    public List<int> Scores() => _scores;

    public int Latest() => _scores.LastOrDefault(0);

    public int PersonalBest() => _scores.Max();

    public List<int> PersonalTopThree() => _scores.OrderDescending().Take(3).ToList();
}