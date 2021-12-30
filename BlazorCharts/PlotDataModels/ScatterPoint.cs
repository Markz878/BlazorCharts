namespace BlazorCharts.PlotDataModels;

public class ScatterPoint
{
    public ScatterPoint(double x, double y, IEnumerable<string>? tooltips = null)
    {
        X = x;
        Y = y;
        TooltipProperties = tooltips;
    }

    public double X { get; }
    public double Y { get; }
    public IEnumerable<string>? TooltipProperties { get; }
}
