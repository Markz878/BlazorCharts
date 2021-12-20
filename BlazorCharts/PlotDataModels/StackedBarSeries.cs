namespace BlazorCharts.PlotDataModels;

public class StackedBarSeries
{
    public StackedBarSeries(IList<string> titles, bool showLabels = true, params StackedBarSerie[] series)
    {
        ArgumentNullException.ThrowIfNull(titles);
        if (titles.Count>10)
        {
            throw new ArgumentException("Stacked bar chart is not suitable for more than 10 data serie.");
        }
        if (series.Length == 0)
        {
            throw new ArgumentException(nameof(series), "Stacked bar chart is not suitable for more than 10 data serie.");
        }
        foreach (StackedBarSerie? serie in series)
        {
            if (serie.Values.Count != titles.Count)
            {
                throw new ArgumentException("Titles count must match each series count");
            }
        }
        Titles = titles;
        ShowLabels = showLabels;
        Series = series;
    }

    public IList<string> Titles { get; }
    public IList<StackedBarSerie> Series { get; }
    public bool ShowLabels { get; }
}
