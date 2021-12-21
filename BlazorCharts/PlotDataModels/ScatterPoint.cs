namespace BlazorCharts.PlotDataModels;

public class ScatterPoint
{
    public ScatterPoint(double x, double y, Dictionary<string, string>? tooltips = null)
    {
        X = x;
        Y = y;
        TooltipProperties = tooltips;
    }

    public double X { get; }
    public double Y { get; }
    public Dictionary<string, string>? TooltipProperties { get; }
}
