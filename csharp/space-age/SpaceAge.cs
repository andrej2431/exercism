public class SpaceAge(int seconds)
{
    private readonly double _earthAge = seconds / 31557600d;

    public double OnEarth() => _earthAge;

    public double OnMercury() => _earthAge / 0.2408467d;

    public double OnVenus() => _earthAge / 0.61519726d;

    public double OnMars() => _earthAge / 1.8808158d;

    public double OnJupiter() => _earthAge / 11.862615d;

    public double OnSaturn() => _earthAge / 29.447498d;

    public double OnUranus() => _earthAge / 84.016846d;

    public double OnNeptune() => _earthAge / 164.79132d;
}