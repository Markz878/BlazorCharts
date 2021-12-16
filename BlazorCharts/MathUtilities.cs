using static System.Math;

namespace BlazorCharts;

internal static class MathUtilities
{
    internal static double RoundTo10(double number, double order, bool toPositiveInfinity)
    {
        return (number, order, toPositiveInfinity) switch
        {
            (_, >= 1, true) => Ceiling(number / order) * order,
            (_, < 1, _) => Round(number, (int)Log10(1 / order), MidpointRounding.AwayFromZero),
            (_, >= 1, false) => Floor(number / order) * order,
            _ => throw new NotImplementedException(),
        };
    }

    internal static RGBColor GetColorFromFraction(double x)
    {
        return x switch
        {
            < 0.25 => new RGBColor(255, MapToBytes(x, 0, 0.25), 0),
            < 0.5 => new RGBColor((byte)(255 - MapToBytes(x, 0.25, 0.5)), 255, 0),
            < 0.75 => new RGBColor(0, 255, MapToBytes(x, 0.5, 0.75)),
            <= 1 => new RGBColor(0, (byte)(255 - MapToBytes(x, 0.75, 1)), 255),
            _ => throw new ArgumentException("Fraction value must be between 0 and 1")
        };
    }

    internal static byte MapToBytes(double x, double min, double max)
    {
        return (byte)((x - min) / (max - min) * byte.MaxValue);
    }
}
