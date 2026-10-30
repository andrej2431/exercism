using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    private static TimeZoneInfo TimeZoneById(string windowsId, string linuxId)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
            TimeZoneInfo.FindSystemTimeZoneById(windowsId) 
            : TimeZoneInfo.FindSystemTimeZoneById(linuxId);
        
    }

    private static TimeZoneInfo TimeZoneById(Location location)
    {
        return location switch
        {
            Location.London => TimeZoneById("GMT Standard Time", "Europe/London"),
            Location.NewYork => TimeZoneById("Eastern Standard Time", "America/New_York"),
            Location.Paris => TimeZoneById("W. Europe Standard Time", "Europe/Paris"),
            _ => throw new ArgumentOutOfRangeException(nameof(location), location, null)
        };
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var timeZone = TimeZoneById(location);
        return TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), timeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentOutOfRangeException(nameof(alertLevel), alertLevel, null)
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var timeZone = TimeZoneById(location);
        return timeZone.IsDaylightSavingTime(dt.AddDays(-7)) != timeZone.IsDaylightSavingTime(dt);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var culture = location switch
        {
            Location.London => new CultureInfo("en-GB"),
            Location.NewYork => new CultureInfo("en-US"),
            Location.Paris => new CultureInfo("fr-FR")
        };
        
        try
        {
            return DateTime.Parse(dtStr, culture);
        }
        catch (FormatException)
        {
            return new DateTime(1, 1, 1);
        }
        
    }
}
