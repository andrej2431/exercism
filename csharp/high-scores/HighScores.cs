public class HighScores(List<int> list)
{
    private List<int> _scores = list;

    public List<int> Scores() => _scores;

    public int Latest() => _scores.LastOrDefault(0);

    public int PersonalBest() => _scores.Max();

    public List<int> PersonalTopThree()
    {
        int top1Index = -1;
        int top2Index = -1;
        int top3Index = -1;

        for (int i = 0; i < _scores.Count; i++)
        {
            if (top1Index == -1 || _scores[i] > _scores[top1Index])
            {
                top3Index = top2Index;
                top2Index = top1Index;
                top1Index = i;
            }
            
            else if (top2Index == -1 || _scores[i] > _scores[top2Index])
            {
                top3Index = top2Index;
                top2Index = i;
            }
            else if (top3Index == -1 || _scores[i] > _scores[top3Index])
            {
                top3Index = i;
            }
        }
        
        var result = new List<int>();

        if (top1Index != -1)
        {
            result.Add(_scores[top1Index]);
        }

        if (top2Index != -1)
        {
            result.Add(_scores[top2Index]);
        }

        if (top3Index != -1)
        {
            result.Add(_scores[top3Index]);
        }
        
        return result;
    }
}