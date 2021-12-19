namespace BlazorCharts.PlotDataModels;

public class ScatterSeries
{
    public IList<ScatterSerie> Series { get; }

    public ScatterSeries(IList<ScatterSerie> series)
    {
        Series = series;
    }
}
