namespace BlazorCharts.PlotDataModels;

public class StackedBarSeries
{
    public IList<string> Titles { get; }
    public IList<StackedBarSerie> Series { get; }
    public bool ShowLabels { get; set; }

    public StackedBarSeries(IList<string> titles, bool showLabels, params StackedBarSerie[] series)
    {
        ArgumentNullException.ThrowIfNull(titles);
        if (titles.Count > 10)
        {
            throw new ArgumentException("Stacked bar chart is not suitable for more than 10 data series.", nameof(titles));
        }
        if (titles.Any(x=>string.IsNullOrEmpty(x)))
        {
            throw new ArgumentException("One of the given titles was null or an empty string.", nameof(titles));
        }
        if (series.Length == 0)
        {
            throw new ArgumentException("Stacked bar chart is not suitable for more than 10 data series.", nameof(series));
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
}
