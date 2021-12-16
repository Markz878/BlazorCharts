namespace BlazorCharts.PlotDataModels;

public class ScatterPoint
{
    public double X { get; set; }
    public double Y { get; set; }
    public Dictionary<string, string> TooltipProperties { get; set; } = new Dictionary<string, string>();
}
