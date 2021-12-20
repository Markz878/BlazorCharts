namespace BlazorCharts.PlotDataModels;

public class StackedBarItem
{
    public double Value { get; }

    public StackedBarItem(double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Stacked bar item can't have a negative value.");
        }
        Value = value;
    }

    public Dictionary<string, string> TooltipProperties { get; set; } = new Dictionary<string, string>();
}
