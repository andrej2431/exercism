
public class Player
{
    private Random rnd;

    public Player()
    {
        rnd = new Random();
    }
    
    public int RollDie()
    {
        return rnd.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
        return rnd.NextDouble()*100;
    }
}
