namespace BlazorCharts.PlotDataModels;

public class StackedBarColumn
{
    public string Title { get; }
    public IList<StackedBarItem> Values { get; }

    public StackedBarColumn(string title, IList<StackedBarItem> values)
    {
        Title = title;
        Values = values;
    }
}
