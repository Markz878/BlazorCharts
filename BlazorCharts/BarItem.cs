namespace BlazorCharts;

public class BarItem
{
    public string Title { get; set; }
    public double Value { get; set; }

    public BarItem(string title, double value)
    {
        Title = title;
        Value = value;
    }
}
