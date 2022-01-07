namespace BlazorCharts.PlotDataModels;

public class ScatterPoint
{
    public double X { get; set; }
    public double Y { get; set; }
    public double R { get; set; }
    public IEnumerable<string>? TooltipProperties { get; }

    public ScatterPoint(double x, double y, double r = 4, IEnumerable<string>? tooltips = null)
    {
        X = x;
        Y = y;
        R = r; 
        TooltipProperties = tooltips;
    }
}
