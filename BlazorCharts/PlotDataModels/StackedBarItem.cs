namespace BlazorCharts.PlotDataModels;

public class StackedBarItem
{
    public double Value { get; set; }
    public IEnumerable<string>? TooltipProperties { get; }

    public StackedBarItem(double value, IEnumerable<string>? tooltips = null)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Stacked bar items can't have a negative value.");
        }
        Value = value;
        TooltipProperties = tooltips;
    }
}
