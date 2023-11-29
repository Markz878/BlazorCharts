using System.Diagnostics.CodeAnalysis;

namespace BlazorCharts.PlotDataModels;

public class StackedBarItem
{
    public required double Value { get; set; }
    public IEnumerable<string>? TooltipProperties { get; set; }

    public StackedBarItem()
    {
    }

    [SetsRequiredMembers]   
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
