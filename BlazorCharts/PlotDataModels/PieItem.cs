namespace BlazorCharts.PlotDataModels;

public class PieItem
{
    public PieItem(string title, double value, string color, string labelColor = "black", IEnumerable<string>? tooltipProperties = null)
    {
        ArgumentNullException.ThrowIfNull(title, nameof(title));
        ArgumentNullException.ThrowIfNull(color, nameof(color));
        if (value<=0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Pie Item value must be larger than 0.");
        }
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