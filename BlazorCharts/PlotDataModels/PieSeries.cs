namespace BlazorCharts.PlotDataModels;

public class PieSeries
{
    public bool ShowLabels { get; set; }
    public PieItem[] PieItems { get; }

    public PieSeries(bool showLabels, params PieItem[] pieItems)
    {
        if (pieItems.Length < 2)
        {
            throw new ArgumentException("Pie series needs at least 2 items.", nameof(pieItems));
        }
        ShowLabels = showLabels;
        PieItems = pieItems;
    }
}
