namespace BlazorCharts.PlotDataModels;

public class PieItem
{
    public PieItem(string title, double value, string color, string labelColor = "black", IEnumerable<string>? tooltipProperties = null)
    {
        Title = title;
        Value = value;
        Color = color;
        LabelColor = labelColor;
        TooltipProperties = tooltipProperties;
    }

    public string Title { get; }
    public double Value { get; }
    public string Color { get; }
    public string LabelColor { get; }
    public IEnumerable<string>? TooltipProperties { get; }
}