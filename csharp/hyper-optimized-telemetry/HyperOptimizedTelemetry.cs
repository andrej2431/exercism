public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];

        buffer[0] = reading switch
        {
            <= -2_147_483_649L => 256-8,
            <= -32_769L => 256 - 4,
            <= -1 => 256 - 2,
            <= 65_535L => 2,
            <= 2_147_483_647L => 256 - 4,
            <= 4_294_967_295L => 4,
            <= 9_223_372_036_854_775_807L => 256-8 
        };
        
        
        Array.Copy(BitConverter.GetBytes(reading), 0, buffer, 1, 8);
        byte filled = buffer[0] > 200 ? (byte)((byte)~buffer[0]+2) :  (byte)9;
        
        for (int i = filled; i < 9; i++)
        {
            buffer[i] = 0;
        }
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        return buffer[0] switch
        {
            256 - 8 => BitConverter.ToInt64(buffer, 1),
            256 - 4 => BitConverter.ToInt32(buffer, 1),
            256 - 2 => BitConverter.ToInt16(buffer, 1),
            2 => BitConverter.ToUInt16(buffer, 1),
            4 => BitConverter.ToUInt32(buffer, 1),
            _ => 0
        };
    }
}
