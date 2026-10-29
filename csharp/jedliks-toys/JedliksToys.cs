class RemoteControlCar
{

    private int _batteryLevel = 100;
    private int _distance = 0;
    
    
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distance} meters";
    }

    public string BatteryDisplay()
    {
        return _batteryLevel > 0 ? $"Battery at {_batteryLevel}%" : "Battery empty";
    }

    public void Drive()
    {
        if (_batteryLevel == 0)
            return;
        
        _distance += 20;
        _batteryLevel -= 1;
    }
}
