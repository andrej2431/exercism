class WeighingMachine
{
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
    
    public int Precision { get; init; }
    public double TareAdjustment { get; set; } = 5;
    public double Weight
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            field = value;
        }
    } = 0;
    
    public string DisplayWeight => $"{(Weight - TareAdjustment).ToString($"N{Precision}")} kg";
}
