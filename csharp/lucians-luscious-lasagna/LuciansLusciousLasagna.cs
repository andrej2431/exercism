class Lasagna
{
    public int ExpectedMinutesInOven()
    {
        return 40;
    }
    
    public int RemainingMinutesInOven(int currentMinutes)
    {
        return ExpectedMinutesInOven() - currentMinutes;
    }

    public int PreparationTimeInMinutes(int layers)
    {
        return 2 * layers;
    }

    public int ElapsedTimeInMinutes(int layers, int currentMinutes)
    {
        return currentMinutes + PreparationTimeInMinutes(layers);
    }
    
    
}
