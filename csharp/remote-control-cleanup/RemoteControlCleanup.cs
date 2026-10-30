public class RemoteControlCar
{

    private CarTelemetry _telemetry;

    public RemoteControlCar()
    {
        _telemetry = new  CarTelemetry();
    }

    public ICarTelemetry Telemetry => _telemetry;
    
    public string CurrentSponsor => _telemetry.CurrentSponsor;


    public string GetSpeed()
    {
        return _telemetry.CurrentSpeed.ToString();
    }

    public interface ICarTelemetry
    {
        public void Calibrate();
        public void SelfTest();
        public void ShowSponsor(string sponsorName);
        public void SetSpeed(decimal amount, string unitsString);
    }


    private class CarTelemetry : ICarTelemetry
    {
        public Speed CurrentSpeed;
        public string CurrentSponsor;

        public CarTelemetry()
        {
            CurrentSpeed = new Speed();
            CurrentSponsor = "";
        }
        
        public void Calibrate()
        {
            
        }

        public void SelfTest()
        {
            
        }

        public void ShowSponsor(string sponsorName)
        {
            CurrentSponsor = sponsorName;
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            CurrentSpeed = new Speed(amount, speedUnits);
        }
    }
    
    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
}

