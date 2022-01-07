namespace BlazorCharts.PlotDataModels;

public class StackedBarSerie
{
    public string Title { get; set; }
    public string Color { get; set; }
    public string LabelColor { get; set; }
    public IList<StackedBarItem> Values { get; }

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