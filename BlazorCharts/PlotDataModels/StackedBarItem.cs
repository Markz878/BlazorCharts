namespace BlazorCharts.PlotDataModels;

public class StackedBarItem
{
    public double Value { get; }

    public StackedBarItem(double value)
    {
        Value = value;
    }

    public Dictionary<string, string> TooltipProperties { get; set; } = new Dictionary<string, string>();
}
