namespace BlazorCharts.Utilities;

internal static class GuardUtilities
{
    internal static bool IsStrictlyAscending(IEnumerable<double> values)
    {
        double previousValue = double.MinValue;
        foreach (double value in values)
        {
            if (value > previousValue)
            {
                previousValue = value;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}
