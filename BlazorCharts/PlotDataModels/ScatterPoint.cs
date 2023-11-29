using System.Diagnostics.CodeAnalysis;

namespace BlazorCharts.PlotDataModels;

public class ScatterPoint
{
    public required double X { get; set; }
    public required double Y { get; set; }
    public required double R { get; set; }
    public IEnumerable<string>? TooltipProperties { get; set; }

    public ScatterPoint()
    {
    }

    [SetsRequiredMembers]
    public ScatterPoint(double x, double y, double r = 4, IEnumerable<string>? tooltips = null)
    {
        X = x;
        Y = y;
        R = r; 
        TooltipProperties = tooltips;
    }
}
