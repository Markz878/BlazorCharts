namespace BlazorCharts.PlotDataModels;

public class StackedBarSerie
{
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

    public string Title { get; }
    public string Color { get; }
    public string LabelColor { get; }
    public IList<StackedBarItem> Values { get; }
}