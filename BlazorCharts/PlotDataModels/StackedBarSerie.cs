using System.Diagnostics.CodeAnalysis;

namespace BlazorCharts.PlotDataModels;

public class StackedBarSerie
{
    public required string Title { get; set; }
    public required string Color { get; set; }
    public required string LabelColor { get; set; }
    public required IList<StackedBarItem> Values { get; set; }

    public StackedBarSerie()
    {
    }

    [SetsRequiredMembers]   
    public StackedBarSerie(string title, string color, string labelColor, IList<StackedBarItem> values)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(color);
        ArgumentNullException.ThrowIfNull(values);
        ArgumentNullException.ThrowIfNull(labelColor);
        if (values.Count == 0)
        {
            throw new ArgumentException("Stacked bar serie values was empty.", nameof(values));
        }
        Title = title;
        Color = color;
        LabelColor = labelColor;
        Values = values;
    }
}