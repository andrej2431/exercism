class RemoteControlCar
{
    private int _speed;
    private int _batteryDrain;
    private int _batteryLevel;
    private int _distance;
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
        _batteryLevel = 100;
        _distance = 0;
    }

    public bool BatteryDrained()
    {
        return _batteryLevel < _batteryDrain;
    }

    public int DistanceDriven()
    {
        return _distance;
    }

    public void Drive()
    {
        if (_batteryLevel < _batteryDrain) return;
        
        _batteryLevel -= _batteryDrain;
        _distance += _speed;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int _distance;
    
    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
            if (car.DistanceDriven() >= _distance)
            {
                return true;
            }
        }

        return false;
    }
}
