namespace BlazorCharts.PlotDataModels;

public class StackedBarItem
{
    public StackedBarItem(double value, string color)
    {
        Value = value;
        Color = color;
    }

    public double Value { get; }
    public string Color { get; }
}