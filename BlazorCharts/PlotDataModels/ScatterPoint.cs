namespace BlazorCharts.PlotDataModels;

public class ScatterPoint
{
    public ScatterPoint(double x, double y, double r = 4, IEnumerable<string>? tooltips = null)
    {
        X = x;
        Y = y;
        R = r; 
        TooltipProperties = tooltips;
    }

    public double X { get; }
    public double Y { get; }
    public double R { get; }
    public IEnumerable<string>? TooltipProperties { get; }
}
