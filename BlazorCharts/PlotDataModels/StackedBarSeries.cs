using System.Diagnostics.CodeAnalysis;

namespace BlazorCharts.PlotDataModels;

public class StackedBarSeries
{
    public required IList<string> Titles { get; set;  }
    public required IList<StackedBarSerie> Series { get; set; }
    public bool ShowLabels { get; set; }

    public StackedBarSeries()
    {
    }

    [SetsRequiredMembers]
    public StackedBarSeries(IList<string> titles, bool showLabels, params StackedBarSerie[] series)
    {
        ArgumentNullException.ThrowIfNull(titles);
        if (titles.Count > 10)
        {
            throw new ArgumentException("Stacked bar chart is not suitable for more than 10 data series.", nameof(titles));
        }
        if (titles.Any(string.IsNullOrEmpty))
        {
            throw new ArgumentException("One of the given titles was null or an empty string.", nameof(titles));
        }
        if (series.Length == 0)
        {
            throw new ArgumentException("No stacked bar chart series given.", nameof(series));
        }
        foreach (StackedBarSerie serie in series)
        {
            if (serie.Values.Count != titles.Count)
            {
                throw new ArgumentException("Titles count must match each series values count");
            }
        }
        Titles = titles;
        ShowLabels = showLabels;
        Series = series;
    }
}
