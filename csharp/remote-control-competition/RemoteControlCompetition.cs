public interface IRemoteControlCar
{
    void Drive();
    
    public int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar : IComparable, IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(object? obj)
    {
        if (obj is ProductionRemoteControlCar car)
        {
            return NumberOfVictories - car.NumberOfVictories switch
            {
                > 0 => 1,
                < 0 => -1,
                _ => 0
            };
        }

        return 1;
    }
}

public class ExperimentalRemoteControlCar: IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        List<ProductionRemoteControlCar> rankings = [prc1, prc2];
        rankings.Sort();
        return rankings;
    }
}
