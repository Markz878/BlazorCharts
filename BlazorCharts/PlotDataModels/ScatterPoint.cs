namespace BlazorCharts.PlotDataModels;

public class ScatterPoint
{
    public ScatterPoint(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }
    public Dictionary<string, string> TooltipProperties { get; set; } = new Dictionary<string, string>();
}
