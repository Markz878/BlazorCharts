using static System.Math;

namespace BlazorCharts.Utilities;

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
}
