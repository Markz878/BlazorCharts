namespace BlazorCharts.PlotDataModels;

public class LineSeries
{
    public IList<LineSerie> Series { get; }

    public LineSeries(IList<LineSerie> series)
    {
        Series = series;
    }
}
