namespace BlazorCharts.PlotDataModels;

public class PieItem
{
    public string Title { get; set; }
    public double Value { get; set; }
    public string Color { get; set; }
    public string LabelColor { get; set; }
    public IEnumerable<string>? TooltipProperties { get; }
    
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
}