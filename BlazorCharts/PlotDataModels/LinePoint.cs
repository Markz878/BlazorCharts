using System.Diagnostics.CodeAnalysis;

namespace BlazorCharts.PlotDataModels;

public class LinePoint
{
    public required double X { get; set; }
    public required double Y { get; set; }

    public LinePoint()
    {
    }

    [SetsRequiredMembers]
    public LinePoint(double x, double y)
    {
        X = x;
        Y = y;
    }
}