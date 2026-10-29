using System.Globalization;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime.TryParse(appointmentDateDescription, out DateTime appointmentDate);
        return appointmentDate;
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return DateTime.Now > appointmentDate ;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        return appointmentDate.Hour is >= 12 and < 18;
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate.ToString(new CultureInfo("en-US"))}.";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15);
    }
}
