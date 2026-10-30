static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        return speed switch
        {
            0 => 0,
            >= 1 and <= 4 => 1,
            >= 5 and <= 8 => 0.9d,
            9 => 0.8d,
            10 => 0.77d,
            
            _ => 0
        };
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return speed * 221 * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)(ProductionRatePerHour(speed) / 60);
    }
}
