namespace BlazorCharts.PlotDataModels;

public class StackedBarSeries
{
    public StackedBarSeries(IList<string> titles, params StackedBarSerie[] series)
    {
        foreach (StackedBarSerie? serie in series)
        {
            if (serie.Values.Count != titles.Count)
            {
                throw new ArgumentException("Titles count must match each series count");
            }
        }
        Titles = titles;
        Series = series;
    }

    public IList<string> Titles { get; set; }
    public IList<StackedBarSerie> Series { get; }
}
