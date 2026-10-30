public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string prefix = phoneNumber.Substring(0, 3);
        string middle = phoneNumber.Substring(4, 3);
        string end =  phoneNumber.Substring(8, 4);
        return (prefix == "212", middle == "555", end);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
