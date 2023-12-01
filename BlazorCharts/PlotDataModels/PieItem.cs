using System.Diagnostics.CodeAnalysis;

namespace BlazorCharts.PlotDataModels;

public class PieItem
{
    public required string Title { get; set; }
    public required double Value { get; set; }
    public required string Color { get; set; }
    public required string LabelColor { get; set; }
    public IEnumerable<string>? TooltipProperties { get; set; }

    public PieItem()
    {
    }

    [SetsRequiredMembers]
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