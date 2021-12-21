namespace BlazorCharts.PlotDataModels;

public class StackedBarSerie
{
    public StackedBarSerie(string title, string color, string textColor, IList<StackedBarItem> values)
    {
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(color);
        ArgumentNullException.ThrowIfNull(values);
        ArgumentNullException.ThrowIfNull(textColor);
        if (values.Count == 0)
        {
            throw new ArgumentException("Stacked bar serie values was empty.", nameof(values));
        }
        Title = title;
        Color = color;
        TextColor = textColor;
        Values = values;
    }

    public string Title { get; }
    public string Color { get; }
    public string TextColor { get; }
    public IList<StackedBarItem> Values { get; }
}