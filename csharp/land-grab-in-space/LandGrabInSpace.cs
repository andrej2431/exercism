using System.Diagnostics.CodeAnalysis;

public struct Coord : IEquatable<Coord>
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
    
    public static bool operator ==(Coord coordA, Coord coordB)
    {
        return  coordA.Equals(coordB);
    }

    public static bool operator !=(Coord coordA, Coord coordB)
    {
        return !(coordA == coordB);
    }

    public override bool Equals(object? obj)
    {
        return obj is Coord coord && Equals(coord);
    }

    public bool Equals(Coord other)
    {
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

public struct Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4): IEquatable<Plot>
{
    public Coord Coord1 = coord1;
    public Coord Coord2 = coord2;
    public Coord Coord3 = coord3;
    public Coord Coord4 = coord4;

    public static bool operator ==(Plot plotA, Plot plotB)
    {
        return plotA.Equals(plotB);
    }

    public static bool operator !=(Plot plotA, Plot plotB)
    {
        return !(plotA == plotB);
    }

    public override bool Equals(object? obj)
    {
        return obj is Plot plot && Equals(plot);
    }

    public bool Equals(Plot other)
    {
        return other.Coord1 == Coord1
               && other.Coord2 == Coord2
               && other.Coord3 == Coord3
               && other.Coord4 == Coord4;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Coord1, Coord2, Coord3, Coord4);
    }

    public double LongestSideLength()
    {
        double[] sideLengths = [
            SideLength(Coord1, Coord2), SideLength(Coord2, Coord3), 
            SideLength(Coord3, Coord4), SideLength(Coord4, Coord1)
        ];

        return sideLengths.Max();
    }
    
    private static double SideLength(Coord coord1, Coord coord2)
    {
        return Math.Sqrt(Math.Pow(Math.Abs(coord1.X-coord2.X), 2) + Math.Pow(Math.Abs(coord1.Y-coord2.Y), 2));
    }
}


public class ClaimsHandler
{
    private readonly List <Plot> _plots = new List<Plot>();
    public void StakeClaim(Plot plot)
    {
        _plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return _plots.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return plot.Equals(_plots.Last());
    }



    public Plot GetClaimWithLongestSide()
    {
        double longestSide = 0;
        Plot longestSidePlot = new Plot();
        foreach (var plot in _plots)
        {
            double plotLargestSide = plot.LongestSideLength();
            if (plotLargestSide > longestSide)
            {
                longestSide = plotLargestSide;
                longestSidePlot = plot;
            }
        }
        
        return longestSidePlot;
    }
}
