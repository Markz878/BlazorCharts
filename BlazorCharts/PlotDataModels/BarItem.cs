namespace BlazorCharts.PlotDataModels;

public class BarItem
{
    public string Title { get; }
    public double Value { get; }
    public Dictionary<string, string> TooltipProperties { get; set; } = new Dictionary<string, string>();

    public BarItem(string title, double value)
    {
        Title = title;
        Value = value;
    }
}
