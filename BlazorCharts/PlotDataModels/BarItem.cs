namespace BlazorCharts.PlotDataModels;

public class BarItem
{
    public string Title { get; }
    public double Value { get; }

    public BarItem(string title, double value)
    {
        Title = title;
        Value = value;
    }
}
